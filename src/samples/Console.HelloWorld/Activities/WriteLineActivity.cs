using YourWay.Activities;
using YourWay.Steps;

namespace Console.HelloWorld.Activities;

public class WriteLineActivity : Activity
{
    public WriteLineActivity()
    {
        Id = "WriteLine.Activity";
        Name = "WriteLine.Activity";

        Steps = new List<Step>();
    }
}