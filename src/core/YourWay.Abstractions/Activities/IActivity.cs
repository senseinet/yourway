using YourWay.Abstractions.ActivityResults;
using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.Steps;
using YourWay.Abstractions.Transitions;

namespace YourWay.Abstractions.Activities;

public interface IActivity
{
    string Id { get; set; }

    string Name { get; set; }

    string DisplayName { get; set; }

    string Description { get; set; }

    bool IsEntryPoint { get; set; }

    ActivityStatus Status { get; set; }

    ICollection<Step> Steps { get; set; }

    public ICollection<Transition> Transitions { get; set; }

    ValueTask<IActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowExecutionContext, ActivityExecutionContext activityExecutionContext, CancellationToken cancellationToken);
}