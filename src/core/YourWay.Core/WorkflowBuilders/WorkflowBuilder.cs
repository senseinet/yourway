using YourWay.Activities;
using YourWay.Extensions;
using YourWay.Models;
using YourWay.Results;
using YourWay.Services;

namespace YourWay.WorkflowBuilders;

public class WorkflowBuilder : IWorkflowBuilder
{
    private readonly IList<IActivityBuilder> _activityBuilders = new List<IActivityBuilder>();
    private readonly IActivityResolver _activityResolver;
    private readonly IList<IConnectionBuilder> _connectionBuilders = new List<IConnectionBuilder>();

    public WorkflowBuilder(
        IActivityResolver activityResolver
    )
    {
        _activityResolver = activityResolver;
    }

    public int Version { get; set; } = 1;

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsSingleton { get; set; }

    public bool IsDisabled { get; set; }

    public Guid Id { get; set; }

    public IReadOnlyList<IActivityBuilder> Activities => _activityBuilders.ToList().AsReadOnly();

    public IWorkflowBuilder AsSingleton(bool value = true)
    {
        throw new NotImplementedException();
    }

    public IActivityBuilder Add<T>(Action<T> setupActivity = default, string name = default) where T : class, IActivity
    {
        var activity = _activityResolver.ResolveActivity(setupActivity);
        var activityBlueprint = activity.FromActivity();

        var activityBuilder = new ActivityBuilder(this, activityBlueprint);

        activityBuilder.Name = name;
        _activityBuilders.Add(activityBuilder);
        return activityBuilder;
    }

    public IActivityBuilder StartWith<T>(Action<T> setup = default, string name = default) where T : class, IActivity
    {
        return Add(setup, name);
    }

    public IConnectionBuilder Connect(
        IActivityBuilder source,
        IActivityBuilder target,
        OutcomeResultName? outcome = default)
    {
        return Connect(() => source, () => target, outcome);
    }

    public IConnectionBuilder Connect(
        Func<IActivityBuilder> source,
        Func<IActivityBuilder> target,
        OutcomeResultName? outcome = default)
    {
        var connectionBuilder = new ConnectionBuilder(this, source, target, outcome);

        _connectionBuilders.Add(connectionBuilder);
        return connectionBuilder;
    }

    public IWorkflowBuilder WithId(Guid id)
    {
        Id = id;
        return this;
    }

    public IWorkflowBuilder WithVersion(int version)
    {
        throw new NotImplementedException();
    }

    public IWorkflowBuilder WithName(string name)
    {
        throw new NotImplementedException();
    }

    public IWorkflowBuilder WithDescription(string description)
    {
        throw new NotImplementedException();
    }

    public WorkflowDefinitionVersion Build()
    {
        var id = 1;
        foreach (var activityBuilder in _activityBuilders)
            if (activityBuilder.Id == Guid.Empty)
                activityBuilder.Id = Guid.NewGuid();

        var activities = _activityBuilders.Select(x => x.BuildActivity()).ToList();
        var connections = _connectionBuilders.Select(x => x.BuildConnection()).ToList();
        var versionId = Guid.NewGuid();
        var definitionId = versionId;

        return new WorkflowDefinitionVersion(
            versionId,
            definitionId,
            Version,
            Name,
            Description,
            activities,
            connections,
            IsSingleton,
            IsDisabled,
            Variables.Empty)
        {
            IsPublished = true,
            IsLatest = true
        };
    }
}