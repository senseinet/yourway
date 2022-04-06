using YourWay.Contexts;
using YourWay.StepResults;

namespace YourWay.Steps;

public class Step : IStep
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public string Description { get; set; }

    public bool IsEntryPoint { get; set; }

    public virtual ValueTask<IStepExecutionResult> ExecuteAsync(ActivityExecutionContext activityExecutionContext, StepExecutionContext context, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}