using YourWay.Contexts;

namespace YourWay.ActivityResults;

public abstract class ActivityExecutionResult : IActivityExecutionResult
{
    public virtual ValueTask ExecuteAsync(
        ActivityExecutionContext activityExecutionContext,
        CancellationToken cancellationToken)
    {
        Execute(activityExecutionContext);
        return new ValueTask();
    }

    protected virtual void Execute(ActivityExecutionContext activityExecutionContext)
    {
    }
}