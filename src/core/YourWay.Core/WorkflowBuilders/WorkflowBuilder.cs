using YourWay.Services;

namespace YourWay.WorkflowBuilders;

public class WorkflowBuilder : IWorkflowBuilder
{
    public Guid Id { get; set; }
    
    public IReadOnlyList<IActivityBuilder> Activities { get; }
}