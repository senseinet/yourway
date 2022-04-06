using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using YourWay.ActivityResults;
using YourWay.Contexts;
using YourWay.Extensions;
using YourWay.Services;

namespace YourWay.Results;

public class FaultWorkflowResult : ActivityExecutionResult
{
    private readonly string errorMessage;
    private readonly Exception exception;

    public FaultWorkflowResult(Exception exception) : this(exception.Message)
    {
        this.exception = exception;
    }

    public FaultWorkflowResult(string errorMessage)
    {
        this.errorMessage = errorMessage;
    }

    public override async ValueTask ExecuteAsync(
        IWorkflowRunner runner,
        WorkflowExecutionContext workflowContext,
        CancellationToken cancellationToken)
    {
        var eventHandlers = workflowContext.ServiceProvider.GetServices<IWorkflowEventHandler>();
        var logger = workflowContext.ServiceProvider.GetRequiredService<ILogger<FaultWorkflowResult>>();
        var currentActivity = workflowContext.CurrentActivity;

        await eventHandlers.InvokeAsync(
            x => x.ActivityFaultedAsync(workflowContext, currentActivity, errorMessage, cancellationToken),
            logger);

        workflowContext.Fault(workflowContext.CurrentActivity, errorMessage, exception);
    }
}