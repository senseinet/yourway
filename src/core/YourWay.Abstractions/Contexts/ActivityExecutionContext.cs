using YourWay.Abstractions.Activities;

namespace YourWay.Abstractions.Contexts
{
    public class ActivityExecutionContext
    {
        public ActivityExecutionContext(IActivity activity)
        {
            Activity = activity;
        }

        public IActivity Activity { get; }
    }
}
