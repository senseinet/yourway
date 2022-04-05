using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.StepResults;

namespace YourWay.Abstractions.Steps;

public interface IStep
{
    string Id { get; set; }

    string Name { get; set; }

    string DisplayName { get; set; }

    string Description { get; set; }

    bool IsEntryPoint { get; set; }

    ValueTask<IStepExecutionResult> ExecuteAsync(ActivityExecutionContext activityExecutionContext, StepExecutionContext context, CancellationToken cancellationToken);
}