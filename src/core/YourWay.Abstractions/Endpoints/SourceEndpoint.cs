using YourWay.Activities;
using YourWay.Results;

namespace YourWay.Endpoints;

public class SourceEndpoint : Endpoint
{
    public SourceEndpoint()
    {
    }

    public SourceEndpoint(IActivity activity, OutcomeResultName outcome = OutcomeResultName.Done) : base(activity)
    {
        Outcome = outcome;
    }

    public OutcomeResultName? Outcome { get; set; }
}