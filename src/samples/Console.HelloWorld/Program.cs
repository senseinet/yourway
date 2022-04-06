using Console.HelloWorld;
using Console.HelloWorld.Activities;
using Microsoft.Extensions.DependencyInjection;
using YourWay.Engine;
using YourWay.Extensions;
using YourWay.Services;

var services = new ServiceCollection()
    .AddYourWay()
    .AddActivity<HelloWorld>()
    .AddActivity<GoodByeWorld>()
    .BuildServiceProvider();

// Invoke the workflow.
var runner = services.GetService<IWorkflowRunner>();
await runner.StartAsync<HelloWorldWorkflow>();

System.Console.ReadLine();