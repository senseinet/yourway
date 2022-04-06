namespace YourWay.Extensions;

public static class ExceptionExtensions
{
    public static bool IsFatal(this Exception ex)
    {
        return ex is OutOfMemoryException;
    }
}