using YourWay.Contexts;

namespace YourWay.StepResults;

public interface IStepExecutionResult
{
    ValueTask ExecuteAsync(StepExecutionContext stepExecutionContext, CancellationToken cancellationToken);
}