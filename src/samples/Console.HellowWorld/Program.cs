using Console.HellowWorld.Activities;
using Console.HellowWorld.Steps;
using YourWay.Abstractions.Activities;
using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.Workflows;
using YourWay.Core.Workflows;

var activity = new WriteLineActivity();
var step1 = new WriteLineStep()
{
    Id = Guid.NewGuid().ToString(),
};
activity.Steps.Add(step1);

var step2 = new WriteLineStep()
{
    Id = Guid.NewGuid().ToString(),
};
activity.Steps.Add(step2);

var workflow = new Workflow();
workflow.Activities.Add(activity);

var workflowHost = new WorkflowHost();
await workflow.ExecuteAsync(new WorkflowExecutionContext(workflow));

System.Console.ReadLine();