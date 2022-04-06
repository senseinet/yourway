using YourWay.Activities;
using YourWay.Endpoints;
using YourWay.Results;

namespace YourWay.Models;

public class Connection
{
    public Connection()
    {
    }

    public Connection(IActivity sourceActivity, IActivity targetActivity) 
        : this(new SourceEndpoint(sourceActivity), new TargetEndpoint(targetActivity))
    {
    }
        
    public Connection(IActivity sourceActivity, IActivity targetActivity, OutcomeResultName sourceEndpointResultName) 
        : this(new SourceEndpoint(sourceActivity, sourceEndpointResultName), new TargetEndpoint(targetActivity))
    {
    }

    public Connection(SourceEndpoint source, TargetEndpoint target)
    {
        Source = source;
        Target = target;
    }

    public SourceEndpoint Source { get; set; }
    public TargetEndpoint Target { get; set; }
}