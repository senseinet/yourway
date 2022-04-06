using YourWay.Activities;
using YourWay.Models;

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
    
    public ICollection<IActivity> Activities { get; } = new List<IActivity>();
    
    public IList<Connection> Connections { get; } = new List<Connection>();
    
    public WorkflowInstance ToInstance()
    {
        var activities = Activities.ToDictionary(x => x.Id, x => x.ToInstance());

        return new WorkflowInstance
        {
            Id = Id,
            DefinitionId = Definition.DefinitionId,
            Version = Definition.Version,
            CorrelationId = CorrelationId,
            ExecutionStatus = Status,
            CreatedAt = CreatedAt,
            StartedAt = StartedAt,
            FinishedAt = FinishedAt,
            FaultedAt = FaultedAt,
            AbortedAt = AbortedAt,
            Activities = activities,
        };
    }
}