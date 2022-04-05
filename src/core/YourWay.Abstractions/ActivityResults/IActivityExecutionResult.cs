using YourWay.Abstractions.Contexts;

namespace YourWay.Abstractions.ActivityResults;

public interface IActivityExecutionResult
{
    ValueTask ExecuteAsync(ActivityExecutionContext activityExecutionContext, CancellationToken cancellationToken);
}