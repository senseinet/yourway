namespace YourWay.Models;

public class Variable
{
    public Variable()
    {
    }

    public Variable(object value)
    {
        Value = value;
    }
    
    public object Value { get; set; }
}