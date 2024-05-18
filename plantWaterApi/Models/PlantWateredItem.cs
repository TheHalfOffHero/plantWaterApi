using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace plantWaterApi.Models
{
    public class PlantWateredItem
    {
        public long Id { get; set; }
        public DateTime WateredDate { get; set; }


        public required long PlantId { get; set; }
        public Plant? Plant { get; set; }
    }
}