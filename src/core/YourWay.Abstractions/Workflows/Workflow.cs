using Newtonsoft.Json.Linq;
using YourWay.Activities;
using YourWay.Models;

namespace YourWay.Workflows;

public class Workflow
{
    public Workflow()
    {
    }

    public Workflow(
        Guid id,
        WorkflowDefinitionVersion definition,
        DateTime createdAt,
        IEnumerable<IActivity> activities,
        IEnumerable<Connection> connections,
        Variables input,
        Guid correlationId) : this()
    {
        Id = id;
        Definition = definition;
        CreatedAt = createdAt;
        CorrelationId = correlationId;
        Activities = activities.ToList();
        Connections = connections.ToList();
        Input = new Variables(input ?? Variables.Empty);
    }

    public Guid Id { get; set; }

    public WorkflowDefinitionVersion Definition { get; }

    public Guid CorrelationId { get; set; }

    public WorkflowExecutionStatus ExecutionStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? PausedAt { get; set; }

    public DateTime? ResumedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public DateTime? FaultedAt { get; set; }

    public DateTime? AbortedAt { get; set; }

    public ICollection<IActivity> Activities { get; } = new List<IActivity>();

    public IList<Connection> Connections { get; } = new List<Connection>();

    public Variables Input { get; set; }

    public Variables Output { get; set; }

    public void Initialize(WorkflowInstance instance)
    {
        if (instance == null)
            throw new ArgumentNullException(nameof(instance));

        var activityLookup = Activities.ToDictionary(x => x.Id);

        Id = instance.Id;
        CorrelationId = instance.CorrelationId;
        ExecutionStatus = instance.ExecutionStatus;
        CreatedAt = instance.CreatedAt;
        StartedAt = instance.StartedAt;
        FinishedAt = instance.FinishedAt;
        FaultedAt = instance.FaultedAt;
        AbortedAt = instance.AbortedAt;

        foreach (var activity in Activities)
        {
            activity.State = new JObject(instance.Activities[activity.Id].State);
            activity.Output = instance.Activities[activity.Id].Output.ToObject<Variables>();
        }
    }

    public WorkflowInstance ToInstance()
    {
        var activities = Activities.ToDictionary(x => x.Id, x => x.ToInstance());

        return new WorkflowInstance
        {
            Id = Id,
            DefinitionId = Definition.DefinitionId,
            Version = Definition.Version,
            CorrelationId = CorrelationId,
            ExecutionStatus = ExecutionStatus,
            CreatedAt = CreatedAt,
            StartedAt = StartedAt,
            FinishedAt = FinishedAt,
            FaultedAt = FaultedAt,
            AbortedAt = AbortedAt,
            Activities = activities
        };
    }
}