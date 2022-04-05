namespace YourWay.Abstractions.Transitions;

public interface ITransition
{
    string Id { get; }

    string Name { get; }

    bool IsEnabled { get; }
}