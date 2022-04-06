using Newtonsoft.Json.Linq;
using YourWay.Activities;
using YourWay.Extensions;
using YourWay.Models;
using YourWay.Workflows;

namespace YourWay.Services;

public class WorkflowFactory : IWorkflowFactory
{
    private readonly IActivityResolver _activityResolver;
    private readonly IClock _clock;
    private readonly Func<IWorkflowBuilder> _workflowBuilder;

    public WorkflowFactory(
        IActivityResolver activityResolver,
        IClock clock,
        Func<IWorkflowBuilder> workflowBuilder
    )
    {
        _activityResolver = activityResolver;
        _clock = clock;
        _workflowBuilder = workflowBuilder;
    }

    public Workflow CreateWorkflow<T>(
        Variables input = default,
        WorkflowInstance workflowInstance = default,
        Guid correlationId = default) where T : IWorkflow, new()
    {
        var workflowDefinition = _workflowBuilder().Build<T>();
        return CreateWorkflow(workflowDefinition, input, workflowInstance, correlationId);
    }

    public Workflow CreateWorkflow(
        WorkflowDefinitionVersion definition,
        Variables input = default,
        WorkflowInstance workflowInstance = default,
        Guid correlationId = default)
    {
        if (definition.IsDisabled)
            throw new InvalidOperationException("Cannot instantiate disabled workflow definitions.");

        var activities = CreateActivities(definition.Activities).ToList();
        var connections = CreateConnections(definition.Connections, activities);
        var id = Guid.NewGuid();
        var workflow = new Workflow(
            id,
            definition,
            _clock.Now(),
            activities,
            connections,
            input,
            correlationId);

        if (workflowInstance != default)
            workflow.Initialize(workflowInstance);

        return workflow;
    }

    private IEnumerable<Connection> CreateConnections(
        IEnumerable<ConnectionDefinition> connectionBlueprints,
        IEnumerable<IActivity> activities)
    {
        var activityDictionary = activities.ToDictionary(x => x.Id);
        return connectionBlueprints.Select(x => CreateConnection(x, activityDictionary));
    }

    private IEnumerable<IActivity> CreateActivities(IEnumerable<ActivityDefinition> activityBlueprints)
    {
        return activityBlueprints.Select(CreateActivity);
    }

    private IActivity CreateActivity(ActivityDefinition definition)
    {
        var activity = _activityResolver.ResolveActivity(definition.Type);

        activity.State = new JObject(definition.State);
        activity.Id = definition.Id;

        return activity;
    }

    private Connection CreateConnection(
        ConnectionDefinition connectionDefinition,
        IDictionary<Guid, IActivity> activityDictionary)
    {
        var source = activityDictionary[connectionDefinition.SourceActivityId];
        var target = activityDictionary[connectionDefinition.DestinationActivityId];
        return new Connection(source, target, connectionDefinition.Outcome);
    }
}