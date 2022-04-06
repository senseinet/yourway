using Microsoft.Extensions.Logging;
using YourWay.Activities;
using YourWay.ActivityResults;
using YourWay.Contexts;
using YourWay.Results;

namespace YourWay.Services;

public class ActivityRunner : IActivityRunner
{
    private readonly ILogger _logger;

    public ActivityRunner(ILogger<ActivityRunner> logger)
    {
        _logger = logger;
    }

    public async ValueTask<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext,
        IActivity activity,
        CancellationToken cancellationToken = default)
    {
        return await RunAsync(
            workflowContext,
            activity,
            a => a.ExecuteAsync(workflowContext, cancellationToken)
        );
    }

    public async ValueTask<ActivityExecutionResult> ResumeAsync(WorkflowExecutionContext workflowContext,
        IActivity activity,
        CancellationToken cancellationToken = default)
    {
        return await RunAsync(
            workflowContext,
            activity,
            a => a.ResumeAsync(workflowContext, cancellationToken)
        );
    }

    private async ValueTask<ActivityExecutionResult> RunAsync(
        WorkflowExecutionContext workflowContext,
        IActivity activity,
        Func<IActivity, ValueTask<ActivityExecutionResult>> invokeAction)
    {
        try
        {
            return await invokeAction(activity);
        }
        catch (Exception e)
        {
            _logger.LogError(
                e,
                "Error while invoking activity {ActivityId} of workflow {WorkflowId}",
                activity.Id,
                workflowContext.Workflow.Id
            );
            return new FaultWorkflowResult(e);
        }
    }
}