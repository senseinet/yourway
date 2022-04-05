using YourWay.Abstractions.Contexts;

namespace YourWay.Abstractions.StepResults;

public interface IStepExecutionResult
{
    ValueTask ExecuteAsync(StepExecutionContext stepExecutionContext, CancellationToken cancellationToken);
}