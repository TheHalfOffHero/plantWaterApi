namespace plantWaterApi;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using plantWaterApi.Models;

public class Plant
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    public string? Location { get; set; }
    public ICollection<PlantWateredItem> PlantWateredItems { get; set; } = new List<PlantWateredItem>();
}
