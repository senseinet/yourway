using YourWay.Activities;
using YourWay.Services;

namespace YourWay.WorkflowBuilders;

public class WorkflowBuilder : IWorkflowBuilder
{
    public Guid Id { get; set; }
    
    public IReadOnlyList<IActivityBuilder> Activities { get; }
    
    public IActivityBuilder StartWith<T>(Action<T> setup = default, string name = default) where T : class, IActivity
    {
        throw new NotImplementedException();
    }
}