using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using YourWay.ActivityResults;
using YourWay.Contexts;
using YourWay.Endpoints;
using YourWay.Extensions;
using YourWay.Services;

namespace YourWay.Results;

/// <summary>
/// Result that holds information about next activity to execute
/// </summary>
public class OutcomeResult : ActivityExecutionResult
{
    public OutcomeResult(IEnumerable<OutcomeResultName> endpointNames)
    {
        EndpointNames = endpointNames.ToList();
    }
    
    public IReadOnlyList<OutcomeResultName> EndpointNames { get; }

    public override async ValueTask ExecuteAsync(IWorkflowRunner runner, WorkflowExecutionContext workflowContext,
        CancellationToken cancellationToken)
    {
        var currentActivity = workflowContext.CurrentActivity;

        foreach (var endpointName in EndpointNames)
        {
            ScheduleNextActivities(workflowContext, new SourceEndpoint(currentActivity, endpointName));
        }
        
        var eventHandlers = workflowContext.ServiceProvider.GetServices<IWorkflowEventHandler>();
        var logger = workflowContext.ServiceProvider.GetRequiredService<ILogger<OutcomeResult>>();
        await eventHandlers.InvokeAsync(x => x.ActivityExecutedAsync(workflowContext, currentActivity, cancellationToken), logger);
    }
    
    private void ScheduleNextActivities(WorkflowExecutionContext workflowContext, SourceEndpoint endpoint)
    {
        var completedActivity = workflowContext.CurrentActivity;
        var connections = workflowContext.Workflow.Connections.Where(x => x.Source.Activity == completedActivity &&
                                                                          (x.Source.Outcome ?? OutcomeResultName.Done) == endpoint.Outcome);
        var activities = connections.Select(x => x.Target.Activity);
            
        workflowContext.ScheduleActivities(activities);
    }
}