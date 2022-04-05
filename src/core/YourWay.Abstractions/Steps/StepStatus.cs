namespace YourWay.Abstractions.Steps;

public enum StepStatus
{
    Idle = 0,
    Queued = 1,
    Running = 2,
    Paused = 3,
    Resumed = 4,
    Executing = 5,
    Finished = 6,
    Faulted = 7,
    Aborted = 8
}