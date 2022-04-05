using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.StepResults;

namespace YourWay.Abstractions.Steps;

public class NoopStepExecutionResult : StepExecutionResult
{
    public override ValueTask ExecuteAsync(StepExecutionContext stepExecutionContext, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}