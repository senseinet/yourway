using YourWay.Activities;

namespace YourWay.Contexts
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
