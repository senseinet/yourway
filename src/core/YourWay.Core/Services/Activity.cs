using YourWay.Activities;
using YourWay.ActivityResults;
using YourWay.Results;

namespace YourWay.Services;

public abstract class Activity : ActivityBase
{
    protected ActivityExecutionResult Outcomes(IEnumerable<OutcomeResultName> names) => new OutcomeResult(names);
    
    protected ActivityExecutionResult Outcome(OutcomeResultName name) => Outcomes(new[] { name });
    
    protected ActivityExecutionResult Done() => Outcome(OutcomeResultName.Done);
}