using YourWay.Abstractions.Steps;

namespace YourWay.Abstractions.Contexts;

public class StepExecutionContext
{
    public StepExecutionContext(IStep step)
    {
        Step = step;
    }

    public IStep Step { get; }
}