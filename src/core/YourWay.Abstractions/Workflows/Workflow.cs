using YourWay.Abstractions.Activities;
using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.Transitions;

namespace YourWay.Abstractions.Workflows;

public class Workflow : IWorkflow
{
    public string Name { get; set; }

    public ICollection<Activity> Activities { get; set; }

    public ICollection<Transition> Transitions { get; set; }

    public Workflow()
    {
        Activities = new List<Activity>();
        Transitions = new List<Transition>();
    }

    public async Task ExecuteAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken)
    {
        var entryPointActivity = Activities.SingleOrDefault(a => a.IsEntryPoint);
        var activityExecutionContext = new ActivityExecutionContext(entryPointActivity);

        await entryPointActivity.ExecuteAsync(workflowExecutionContext, activityExecutionContext, cancellationToken);

        var nextExecutions = Transitions.Where(t => t.SourceEndpoint.ActivityId == entryPointActivity.Id).Select(t => t.DestinationEndpoint.ActivityId);

        while (nextExecutions.Any())
        {
            foreach (var nextExecution in nextExecutions)
            {
                var nextActivityToExecute = Activities.SingleOrDefault(a => a.Id == nextExecution);

                await nextActivityToExecute.ExecuteAsync(workflowExecutionContext, new ActivityExecutionContext(nextActivityToExecute), cancellationToken);
            }

            nextExecutions = Transitions.Where(t => nextExecutions.Contains(t.SourceEndpoint.ActivityId))
                .Select(t => t.DestinationEndpoint.ActivityId);
        }
    }
}