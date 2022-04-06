using YourWay.Services;

namespace YourWay.Workflows;

public interface IWorkflow
{
    void Build(IWorkflowBuilder builder);
}