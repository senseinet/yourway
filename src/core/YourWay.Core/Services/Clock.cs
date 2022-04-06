namespace YourWay.Services;

public class Clock : IClock
{
    public DateTime Now()
    {
        return DateTime.UtcNow;
    }
}