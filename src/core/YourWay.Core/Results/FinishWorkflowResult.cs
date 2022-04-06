using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using YourWay.ActivityResults;
using YourWay.Contexts;
using YourWay.Extensions;
using YourWay.Services;

namespace YourWay.Results;

public class FinishWorkflowResult : ActivityExecutionResult
{
    public override async ValueTask ExecuteAsync(
        IWorkflowRunner runner,
        WorkflowExecutionContext workflowContext,
        CancellationToken cancellationToken)
    {
        var currentActivity = workflowContext.CurrentActivity;
        var eventHandlers = workflowContext.ServiceProvider.GetServices<IWorkflowEventHandler>();
        var logger = workflowContext.ServiceProvider.GetRequiredService<ILogger<OutcomeResult>>();
        await eventHandlers.InvokeAsync(
            x => x.ActivityExecutedAsync(workflowContext, currentActivity, cancellationToken),
            logger);

        workflowContext.Finish();
    } 
}