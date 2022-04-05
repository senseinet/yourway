using YourWay.Abstractions.ActivityResults;
using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.Steps;

namespace YourWay.Abstractions.Activities;

public interface IActivity
{
    string Id { get; set; }

    string Name { get; set; }

    string DisplayName { get; set; }

    string Description { get; set; }

    ActivityStatus Status { get; set; }

    ICollection<Step> Steps { get; set; }

    ValueTask<IActivityExecutionResult> ExecuteAsync(ActivityExecutionContext context, CancellationToken cancellationToken);
}