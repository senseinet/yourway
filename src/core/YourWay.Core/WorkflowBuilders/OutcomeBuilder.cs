using YourWay.Activities;
using YourWay.Models;
using YourWay.Results;
using YourWay.Services;

namespace YourWay.WorkflowBuilders;

public class OutcomeBuilder : IOutcomeBuilder
{
    public OutcomeBuilder(IWorkflowBuilder workflowBuilder, IActivityBuilder source, OutcomeResultName? outcome)
    {
        WorkflowBuilder = workflowBuilder;
        Source = source;
        Outcome = outcome;
    }

    public IWorkflowBuilder WorkflowBuilder { get; }
    public IActivityBuilder Source { get; }
    public OutcomeResultName? Outcome { get; }

    public IActivityBuilder Then<T>(Action<T> setup = default, Action<IActivityBuilder> branch = default,
        string name = default) where T : class, IActivity
    {
        var target = WorkflowBuilder.Add(setup, name);
        branch?.Invoke(target);

        WorkflowBuilder.Connect(Source, target, Outcome);
        return target;
    }

    public WorkflowDefinitionVersion Build()
    {
        return WorkflowBuilder.Build();
    }

    public IConnectionBuilder Then(string activityName)
    {
        return WorkflowBuilder.Connect(
            () => Source,
            () => WorkflowBuilder.Activities.First(x => x.Name == activityName),
            Outcome);
    }
}