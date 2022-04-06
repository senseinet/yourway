using YourWay.Contexts;

namespace YourWay.ActivityResults;

public class NoopActivityExecutionResult : ActivityExecutionResult
{
    protected override void Execute(ActivityExecutionContext activityExecutionContext)
    {
        // Noop.
    }
}