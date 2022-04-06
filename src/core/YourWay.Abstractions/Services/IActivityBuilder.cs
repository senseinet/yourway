using YourWay.Activities;

namespace YourWay.Services;

public interface IActivityBuilder
{
    Guid Id { get; set; }
    
    string Name { get; set; }
    
    IReadOnlyList<IStepBuilder> Steps { get; }
    
    IActivityBuilder StartWith<T>(Action<T> setup = default, string name = null) where T: class, IActivity;
    
    IActivityBuilder Add<T>(Action<T> setup = default, string name = null) where T : class, IActivity;
    
    IActivityBuilder Then<T>(Action<T> setup = null, Action<IActivityBuilder> branch = null, string name = null) where T : class, IActivity;
}