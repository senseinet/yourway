using YourWay.Activities;
using YourWay.Models;

namespace YourWay.Extensions;

public static class ActivityDefinitionExtensions
{
    public static ActivityDefinition FromActivity(this IActivity activity)
    {
        return new ActivityDefinition(activity.Id, activity.Type, activity.State);
    }
}