using YourWay.Abstractions.ActivityResults;
using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.Steps;

namespace YourWay.Abstractions.Activities;

public abstract class Activity : IActivity
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public string Description { get; set; }

    public ActivityStatus Status { get; set; }

    public ICollection<Step> Steps { get; set; }

    public async ValueTask<IActivityExecutionResult> ExecuteAsync(ActivityExecutionContext context, CancellationToken cancellationToken)
    {
        foreach (var step in Steps)
        {
            await step.ExecuteAsync(new StepExecutionContext(step), cancellationToken);
        }

        return new NoopActivityExecutionResult();
    }
}