using YourWay.Contexts;
using YourWay.StepResults;

namespace YourWay.Steps;

public interface IStep
{
    string Id { get; set; }

    string Name { get; set; }

    string DisplayName { get; set; }

    string Description { get; set; }

    bool IsEntryPoint { get; set; }

    ValueTask<IStepExecutionResult> ExecuteAsync(ActivityExecutionContext activityExecutionContext,
        StepExecutionContext context, CancellationToken cancellationToken);
}