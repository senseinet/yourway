using YourWay.Models;

namespace YourWay.Services;

public class WorkflowRegistry : IWorkflowRegistry
{
    public Task<IEnumerable<(WorkflowDefinitionVersion, ActivityDefinition)>> ListByStartActivityAsync(string activityType, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<WorkflowDefinitionVersion> GetWorkflowDefinitionAsync(Guid id, WorkflowVersion version, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}