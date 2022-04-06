using YourWay.Contexts;
using YourWay.Services;

namespace YourWay.ActivityResults;

public interface IActivityExecutionResult
{
    ValueTask ExecuteAsync(IWorkflowRunner runner, WorkflowExecutionContext workflowContext,
        CancellationToken cancellationToken);
}