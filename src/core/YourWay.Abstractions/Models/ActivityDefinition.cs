using Newtonsoft.Json.Linq;

namespace YourWay.Models;

public class ActivityDefinition
{
    public ActivityDefinition()
    {
        State = new JObject();
    }

    public ActivityDefinition(Guid id, string type, JObject state, int left = 0, int top = 0)
    {
        Id = id;
        Type = type;
        Left = left;
        Top = top;
        State = new JObject(state);
    }

    public Guid Id { get; set; }
    
    public string Type { get; set; }

    public string Name
    {
        get => State.ContainsKey(nameof(Name).ToLower()) ? State[nameof(Name).ToLower()].Value<string>() : default;
        set => State[nameof(Name).ToLower()] = value;
    }

    public string DisplayName { get; set; }
    
    public string Description { get; set; }
    
    public int Left { get; set; }
    
    public int Top { get; set; }
    
    public JObject State { get; set; }
}