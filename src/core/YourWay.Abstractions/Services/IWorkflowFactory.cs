using YourWay.Models;
using YourWay.Workflows;

namespace YourWay.Services;

public interface IWorkflowFactory
{
    Workflow CreateWorkflow<T>(
        Variables input = default,
        WorkflowInstance workflowInstance = default,
        Guid correlationId = default)
        where T : IWorkflow, new();

    Workflow CreateWorkflow(
        WorkflowDefinitionVersion definition,
        Variables input = default,
        WorkflowInstance workflowInstance = default,
        Guid correlationId = default);
}