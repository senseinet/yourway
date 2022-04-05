using YourWay.Abstractions.Contexts;

namespace YourWay.Abstractions.StepResults;

public abstract class StepExecutionResult : IStepExecutionResult
{
    public virtual ValueTask ExecuteAsync(
        StepExecutionContext stepExecutionContext,
        CancellationToken cancellationToken)
    {
        Execute(stepExecutionContext);
        return new ValueTask();
    }

    protected virtual void Execute(StepExecutionContext activityExecutionContext)
    {
    }
}