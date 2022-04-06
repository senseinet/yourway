using YourWay.Contexts;
using YourWay.Services;

namespace YourWay.ActivityResults;

public class NoopActivityExecutionResult : ActivityExecutionResult
{
    protected override void Execute(IWorkflowRunner runner, WorkflowExecutionContext workflowContext)
    {
        // Noop.
    }
}