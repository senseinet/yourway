using YourWay.Abstractions.Contexts;

namespace YourWay.Abstractions.ActivityResults;

public class NoopActivityExecutionResult : ActivityExecutionResult
{
    protected override void Execute(ActivityExecutionContext activityExecutionContext)
    {
        // Noop.
    }
}