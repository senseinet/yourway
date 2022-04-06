namespace YourWay.Transitions;

public interface ITransition
{
    string Id { get; }

    string Name { get; }

    bool IsEnabled { get; }
}