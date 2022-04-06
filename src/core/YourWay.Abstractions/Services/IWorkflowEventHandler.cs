using YourWay.Activities;
using YourWay.Contexts;
using YourWay.Steps;

namespace YourWay.Services;

public interface IWorkflowEventHandler
{
    ValueTask ActivityExecutedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity, CancellationToken cancellationToken);
    ValueTask ActivityPausedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity, CancellationToken cancellationToken);
    ValueTask ActivityResumedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity, CancellationToken cancellationToken);
    ValueTask ActivityFaultedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity, string message, CancellationToken cancellationToken);
    ValueTask ActivityAbortedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity, string message, CancellationToken cancellationToken);

    ValueTask StepExecutedAsync(ActivityExecutionContext activityExecutionContext, IStep step, CancellationToken cancellationToken);
    ValueTask StepPausedAsync(ActivityExecutionContext activityExecutionContext, IStep step, CancellationToken cancellationToken);
    ValueTask StepResumedAsync(ActivityExecutionContext activityExecutionContext, IStep step, CancellationToken cancellationToken);
    ValueTask StepFaultedAsync(ActivityExecutionContext activityExecutionContext, IStep step, string message, CancellationToken cancellationToken);
    ValueTask StepAbortedAsync(ActivityExecutionContext activityExecutionContext, IStep step, string message, CancellationToken cancellationToken);
    
    ValueTask WorkflowExecutedAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken);
    ValueTask WorkflowPausedAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken);
    ValueTask WorkflowResumedAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken);
    ValueTask WorkflowFaultedAsync(WorkflowExecutionContext workflowExecutionContext, string message, CancellationToken cancellationToken);
}