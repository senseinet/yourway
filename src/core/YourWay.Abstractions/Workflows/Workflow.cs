using YourWay.Activities;
using YourWay.Contexts;
using YourWay.Models;
using YourWay.Transitions;

namespace YourWay.Workflows;

public class Workflow
{
    public Guid Id { get; set; }
    
    public WorkflowDefinitionVersion Definition { get; }
    
    public Guid CorrelationId { get; set; }
    
    public WorkflowExecutionStatus Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? StartedAt { get; set; }
    
    public DateTime? PausedAt { get; set; }
    
    public DateTime? ResumedAt { get; set; }
    
    public DateTime? FinishedAt { get; set; }
    
    public DateTime? FaultedAt { get; set; }
    
    public DateTime? AbortedAt { get; set; }
    
    public IList<Connection> Connections { get; } = new List<Connection>();
}