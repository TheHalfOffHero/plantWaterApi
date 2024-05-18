using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plantWaterApi;

namespace plantWaterApi.Models
{
    public class PlantWateredItemContext : DbContext
    {
        public PlantWateredItemContext(DbContextOptions<PlantWateredItemContext> options)
            : base(options)
    {
    }

    public DbSet<PlantWateredItem> PlantWateredItems { get; set; } = null!;
    public DbSet<plantWaterApi.Plant> Plant { get; set; } = default!;
    }
}