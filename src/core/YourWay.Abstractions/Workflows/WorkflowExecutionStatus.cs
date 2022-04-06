namespace YourWay.Workflows;

public enum WorkflowExecutionStatus
{
    Idle = 0,
    Running = 1,
    Paused = 2,
    Resumed = 3,
    Executing = 4,
    Finished = 5,
    Faulted = 6,
    Aborted = 7
}