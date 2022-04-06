using YourWay.Activities;
using YourWay.ActivityResults;
using YourWay.Contexts;

namespace YourWay.Services;

public interface IActivityRunner
{
    ValueTask<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext, IActivity activity,
        CancellationToken cancellationToken = default);

    ValueTask<ActivityExecutionResult> ResumeAsync(WorkflowExecutionContext workflowContext, IActivity activity,
        CancellationToken cancellationToken = default);
}