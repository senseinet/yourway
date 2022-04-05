using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.StepResults;

namespace YourWay.Abstractions.Steps;

public class Step : IStep
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public string Description { get; set; }

    public virtual ValueTask<IStepExecutionResult> ExecuteAsync(StepExecutionContext context, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}