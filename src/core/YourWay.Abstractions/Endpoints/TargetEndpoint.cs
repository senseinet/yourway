using YourWay.Activities;

namespace YourWay.Endpoints;

public class TargetEndpoint : Endpoint
{
    public TargetEndpoint()
    {
    }

    public TargetEndpoint(IActivity activity) : base(activity)
    {
    }
}