using YourWay.Contexts;
using YourWay.StepResults;

namespace YourWay.Steps;

public class NoopStepExecutionResult : StepExecutionResult
{
    public override ValueTask ExecuteAsync(StepExecutionContext stepExecutionContext, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}