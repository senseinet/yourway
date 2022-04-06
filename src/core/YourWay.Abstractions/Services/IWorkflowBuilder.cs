using YourWay.Activities;
using YourWay.Models;
using YourWay.Results;

namespace YourWay.Services;

public interface IWorkflowBuilder
{
    Guid Id { get; set; }

    IReadOnlyList<IActivityBuilder> Activities { get; }
    IWorkflowBuilder WithId(Guid id);
    IWorkflowBuilder WithVersion(int version);
    IWorkflowBuilder WithName(string name);
    IWorkflowBuilder WithDescription(string description);
    IWorkflowBuilder AsSingleton(bool value = true);
    IActivityBuilder Add<T>(Action<T> setupActivity = default, string name = default) where T : class, IActivity;
    IActivityBuilder StartWith<T>(Action<T> setup = default, string name = default) where T : class, IActivity;
    IConnectionBuilder Connect(IActivityBuilder source, IActivityBuilder target, OutcomeResultName? outcome = default);

    IConnectionBuilder Connect(Func<IActivityBuilder> source, Func<IActivityBuilder> target,
        OutcomeResultName? outcome = default);

    WorkflowDefinitionVersion Build();
}