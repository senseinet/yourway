using System.ComponentModel.DataAnnotations;
using Console.HelloWorld.Activities;
using Console.HelloWorld.Steps;
using YourWay.Abstractions.Endpoints;
using YourWay.Abstractions.Transitions;
using YourWay.Abstractions.Workflows;
using YourWay.Core.Workflows;

var activity = new WriteLineActivity()
{
    IsEntryPoint = true
};

var step1Id = Guid.NewGuid().ToString();
var step2Id = Guid.NewGuid().ToString();

var step1 = new WriteLineStep()
{
    Id = step1Id,
    IsEntryPoint = true
};
activity.Steps.Add(step1);

var step2 = new WriteLineStep()
{
    Id = step2Id,
};
activity.Steps.Add(step2);

var transition = new Transition
{
    SourceEndpoint = new SourceEndpoint()
    {
        StepId = step1Id
    },
    DestinationEndpoint = new DestinationEndpoint()
    {
        StepId = step2Id
    }
};
activity.Transitions.Add(transition);

var workflow = new Workflow();
workflow.Activities.Add(activity);

var workflowHost = new WorkflowHost();

workflowHost.Workflows.Add(workflow);

await workflowHost.ExecuteWorkflows(new CancellationToken());

System.Console.ReadLine();