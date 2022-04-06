using YourWay.Models;
using YourWay.Services;
using YourWay.Workflows;

namespace YourWay.Extensions;

public static class WorkflowBuilderExtensions
{
    public static WorkflowDefinitionVersion Build<T>(this IWorkflowBuilder builder) where T : IWorkflow, new()
    {
        var workflow = new T();
        builder.WithId(Guid.NewGuid());
        workflow.Build(builder);

        return builder.Build();
    }
}