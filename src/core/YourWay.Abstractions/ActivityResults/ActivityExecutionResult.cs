using YourWay.Contexts;
using YourWay.Services;

namespace YourWay.ActivityResults;

public abstract class ActivityExecutionResult : IActivityExecutionResult
{
    public virtual ValueTask ExecuteAsync(IWorkflowRunner runner, WorkflowExecutionContext workflowContext, CancellationToken cancellationToken)
    {
        Execute(runner, workflowContext);
        return ValueTask.CompletedTask;
    }

    protected virtual void Execute(IWorkflowRunner runner, WorkflowExecutionContext workflowContext)
    {
    }
}