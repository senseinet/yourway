using YourWay.Activities;

namespace YourWay.Endpoints;

public class Endpoint
{
    protected Endpoint()
    {
    }

    protected Endpoint(IActivity activity)
    {
        Activity = activity;
    }

    public IActivity Activity { get; set; }
}