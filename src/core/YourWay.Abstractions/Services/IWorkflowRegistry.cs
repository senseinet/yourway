using YourWay.Models;

namespace YourWay.Services;

public interface IWorkflowRegistry
{
    Task<IEnumerable<(WorkflowDefinitionVersion, ActivityDefinition)>> ListByStartActivityAsync(
        string activityType,
        CancellationToken cancellationToken = default);

    Task<WorkflowDefinitionVersion> GetWorkflowDefinitionAsync(
        Guid id,
        WorkflowVersion version,
        CancellationToken cancellationToken = default);
}