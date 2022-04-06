namespace YourWay.Models;

public class ConnectionDefinition
{
    public ConnectionDefinition()
    {
    }

    public ConnectionDefinition(Guid sourceActivityId, Guid destinationActivityId, string outcome)
    {
        SourceActivityId = sourceActivityId;
        DestinationActivityId = destinationActivityId;
        Outcome = outcome;
    }
        
    public Guid SourceActivityId { get; set; }
    
    public Guid DestinationActivityId { get; set; }
    
    public string Outcome { get; set; }
}