using YourWay.Activities;
using YourWay.Contexts;
using YourWay.Steps;

namespace YourWay.Services;

public abstract class WorkflowEventHandlerBase : IWorkflowEventHandler
{
    public virtual ValueTask ActivityExecutedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask ActivityPausedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask ActivityResumedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask ActivityFaultedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity, string message,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask ActivityAbortedAsync(WorkflowExecutionContext workflowExecutionContext, IActivity activity, string message,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask StepExecutedAsync(ActivityExecutionContext activityExecutionContext, IStep step,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask StepPausedAsync(ActivityExecutionContext activityExecutionContext, IStep step,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask StepResumedAsync(ActivityExecutionContext activityExecutionContext, IStep step,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask StepFaultedAsync(ActivityExecutionContext activityExecutionContext, IStep step, string message,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask StepAbortedAsync(ActivityExecutionContext activityExecutionContext, IStep step, string message,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask WorkflowExecutedAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask WorkflowPausedAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask WorkflowResumedAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual ValueTask WorkflowFaultedAsync(WorkflowExecutionContext workflowExecutionContext, string message,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}