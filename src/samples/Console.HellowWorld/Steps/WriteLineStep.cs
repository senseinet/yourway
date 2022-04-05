using YourWay.Abstractions.ActivityResults;
using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.StepResults;
using YourWay.Abstractions.Steps;

namespace Console.HellowWorld.Steps;

public class WriteLineStep : Step
{
    public override ValueTask<IStepExecutionResult> ExecuteAsync(StepExecutionContext context, CancellationToken cancellationToken)
    {
        System.Console.WriteLine($"Step {this.Id} executed");
        return ValueTask.FromResult<IStepExecutionResult>(new NoopStepExecutionResult());
    }
}