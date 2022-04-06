using YourWay.Contexts;
using YourWay.StepResults;
using YourWay.Steps;

namespace Console.HelloWorld.Steps;

public class WriteLineStep : Step
{
    public override ValueTask<IStepExecutionResult> ExecuteAsync(ActivityExecutionContext activityExecutionContext, StepExecutionContext context, CancellationToken cancellationToken)
    {
        System.Console.WriteLine($"Step {this.Id} executed");
        return ValueTask.FromResult<IStepExecutionResult>(new NoopStepExecutionResult());
    }
}