using YourWay.Models;

namespace YourWay.Persistence;

public class MemoryWorkflowInstanceStore : IWorkflowInstanceStore
{
    public ValueTask<WorkflowInstance> SaveAsync(WorkflowInstance instance,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}