namespace YourWay.Services;

public interface IWorkflowBuilder
{
    Guid Id { get; set; }
    
    IReadOnlyList<IActivityBuilder> Activities { get; }
}