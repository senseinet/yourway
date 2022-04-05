using YourWay.Abstractions.ActivityResults;
using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.Steps;
using YourWay.Abstractions.Transitions;

namespace YourWay.Abstractions.Activities;

public abstract class Activity : IActivity
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public string Description { get; set; }

    public bool IsEntryPoint { get; set; }

    public ActivityStatus Status { get; set; }

    public ICollection<Step> Steps { get; set; }

    public ICollection<Transition> Transitions { get; set; }

    public Activity()
    {
        Steps = new List<Step>();
        Transitions = new List<Transition>();
    }

    public async ValueTask<IActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowExecutionContext, ActivityExecutionContext activityExecutionContext, CancellationToken cancellationToken)
    {
        var entryStep = Steps.SingleOrDefault(s => s.IsEntryPoint);
        await entryStep.ExecuteAsync(activityExecutionContext, new StepExecutionContext(entryStep), cancellationToken);

        var nextExecutions = activityExecutionContext.Activity.Transitions.Where(t => t.SourceEndpoint.StepId == entryStep.Id).Select(t => t.DestinationEndpoint.StepId).ToList();

        while (nextExecutions.Any())
        {
            foreach (var nextExecution in nextExecutions)
            {
                var nextStepToExecute = Steps.SingleOrDefault(a => a.Id == nextExecution);

                await nextStepToExecute.ExecuteAsync(activityExecutionContext, new StepExecutionContext(nextStepToExecute), cancellationToken);
            }

            nextExecutions = activityExecutionContext.Activity.Transitions.Where(t => nextExecutions.Contains(t.SourceEndpoint.StepId))
                .Select(t => t.DestinationEndpoint.StepId).ToList();
        }

        return new NoopActivityExecutionResult();
    }
}