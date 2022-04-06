namespace YourWay.Models;

public class WorkflowDefinitionVersion
{
    public WorkflowDefinitionVersion()
    {
        Activities = new List<ActivityDefinition>();
        Connections = new List<ConnectionDefinition>();
        Variables = new Variables();
    }

    public WorkflowDefinitionVersion(
        Guid id,
        Guid definitionId,
        int version,
        string name,
        string description,
        IEnumerable<ActivityDefinition> activities,
        IEnumerable<ConnectionDefinition> connections,
        bool isSingleton,
        bool isDisabled,
        Variables variables)
    {
        Id = id;
        DefinitionId = definitionId;
        Version = version;
        Name = name;
        Description = description;
        Activities = activities.ToList();
        Connections = connections.ToList();
        IsSingleton = isSingleton;
        IsDisabled = isDisabled;
        Variables = variables;
    }

    public Guid Id { get; set; }

    public Guid DefinitionId { get; set; }

    public int Version { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<ActivityDefinition> Activities { get; set; }

    public ICollection<ConnectionDefinition> Connections { get; set; }

    public Variables Variables { get; set; }

    public bool IsSingleton { get; set; }

    public bool IsDisabled { get; set; }

    public bool IsPublished { get; set; }

    public bool IsLatest { get; set; }
}