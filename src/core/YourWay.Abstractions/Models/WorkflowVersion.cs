namespace YourWay.Models;

public class WorkflowVersion
{
    public Version Version { get; set; }

    public string Description { get; set; }

    public bool IsPublished { get; private set; }
}