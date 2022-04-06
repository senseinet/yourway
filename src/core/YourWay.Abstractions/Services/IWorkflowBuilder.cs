using YourWay.Activities;

namespace YourWay.Services;

public interface IWorkflowBuilder
{
    Guid Id { get; set; }
    
    IReadOnlyList<IActivityBuilder> Activities { get; }
    
    IActivityBuilder StartWith<T>(Action<T> setup = default, string name = default) where T: class, IActivity;
}