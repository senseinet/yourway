using YourWay.Contexts;

namespace YourWay.ActivityResults;

public interface IActivityExecutionResult
{
    ValueTask ExecuteAsync(ActivityExecutionContext activityExecutionContext, CancellationToken cancellationToken);
}