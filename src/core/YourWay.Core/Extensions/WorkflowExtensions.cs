using YourWay.Activities;
using YourWay.Workflows;

namespace YourWay.Extensions;

public static class WorkflowExtensions
{
    public static bool IsExecuting(this Workflow workflow)
    {
        return workflow.ExecutionStatus == WorkflowExecutionStatus.Executing;
    }

    public static IEnumerable<IActivity> GetStartActivities(this Workflow workflow)
    {
        var targetActivityIds = workflow.Connections.Select(x => x.Target.Activity.Id).Distinct().ToLookup(x => x);

        var query =
            from activity in workflow.Activities
            where !targetActivityIds.Contains(activity.Id)
            select activity;

        return query;
    }
}