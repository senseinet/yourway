using YourWay.Activities;

namespace YourWay.Models.Extensions;

public static class ActivityDefinitionExtensions
{
    public static ActivityDefinition FromActivity(IActivity activity)
    {
        return new ActivityDefinition(activity.Id, activity.Type, activity.State, 0, 0);
    }
}