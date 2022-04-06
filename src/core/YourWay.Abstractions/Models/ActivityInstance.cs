using Newtonsoft.Json.Linq;

namespace YourWay.Models;

public class ActivityInstance
{
    public Guid Id { get; set; }
    
    public string Type { get; set; }
    
    public JObject State { get; set; }
    
    public JObject Output { get; set; }
}