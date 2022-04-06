using YourWay.Workflows;

namespace YourWay.Models;

public class WorkflowInstance
{
    public Guid Id { get; set; }
    
    public Guid DefinitionId { get; set; }
    
    public int Version { get; set; }
    
    public WorkflowExecutionStatus ExecutionStatus { get; set; }
    
    public Guid CorrelationId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? StartedAt { get; set; }
    
    public DateTime? PausedAt { get; set; }
    
    public DateTime? ResumedAt { get; set; }
    
    public DateTime? FinishedAt { get; set; }
    
    public DateTime? FaultedAt { get; set; }
    
    public DateTime? AbortedAt { get; set; }
    
    public IDictionary<string, ActivityInstance> Activities { get; set; } = new Dictionary<string, ActivityInstance>();
}