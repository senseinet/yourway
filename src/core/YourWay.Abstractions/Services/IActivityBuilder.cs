using YourWay.Activities;
using YourWay.Models;
using YourWay.Results;

namespace YourWay.Services;

public interface IActivityBuilder
{
    Guid Id { get; set; }
    string Name { get; set; }
    ActivityDefinition Activity { get; }
    IActivityBuilder StartWith<T>(Action<T> setup = default, string name = null) where T : class, IActivity;
    IActivityBuilder Add<T>(Action<T> setup = default, string name = null) where T : class, IActivity;
    IOutcomeBuilder When(OutcomeResultName? outcome);

    IActivityBuilder Then<T>(Action<T> setup = null, Action<IActivityBuilder> branch = null, string name = null)
        where T : class, IActivity;

    IActivityBuilder WithName(string name);
    IActivityBuilder WithDisplayName(string displayName);
    IActivityBuilder WithDescription(string description);
    IWorkflowBuilder Then(string activityName);
    IActivityBuilder Then(IActivityBuilder targetActivity);
    WorkflowDefinitionVersion Build();
    ActivityDefinition BuildActivity();
}