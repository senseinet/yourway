using YourWay.Models;

namespace YourWay.Persistence;

public interface IWorkflowInstanceStore
{
    ValueTask<WorkflowInstance> SaveAsync(WorkflowInstance instance, CancellationToken cancellationToken = default);
}