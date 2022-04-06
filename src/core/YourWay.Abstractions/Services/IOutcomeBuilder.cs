using YourWay.Activities;
using YourWay.Models;
using YourWay.Results;

namespace YourWay.Services;

public interface IOutcomeBuilder
{
    IActivityBuilder Source { get; }

    OutcomeResultName? Outcome { get; }

    IActivityBuilder Then<T>(Action<T> setup = default, Action<IActivityBuilder> branch = default,
        string name = default) where T : class, IActivity;

    WorkflowDefinitionVersion Build();

    IConnectionBuilder Then(string activityName);
}