using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plantWaterApi.Models;

namespace plantWaterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantWateredItemController : ControllerBase
    {
        private readonly PlantWateredItemContext _context;

        public PlantWateredItemController(PlantWateredItemContext context)
        {
            _context = context;
        }

        // GET: api/PlantWateredItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantWateredItem>>> GetPlantWateredItems()
        {
            return await _context.PlantWateredItems.ToListAsync();
        }

        // GET: api/PlantWateredItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantWateredItem>> GetPlantWateredItem(long id)
        {
            var plantWateredItem = await _context.PlantWateredItems.FindAsync(id);

            if (plantWateredItem == null)
            {
                return NotFound();
            }

            return plantWateredItem;
        }

        // PUT: api/PlantWateredItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantWateredItem(long id, PlantWateredItem plantWateredItem)
        {
            if (id != plantWateredItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantWateredItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantWateredItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlantWateredItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlantWateredItem>> PostPlantWateredItem(PlantWateredItem plantWateredItem)
        {
            var plant = _context.Plant.Find(plantWateredItem.PlantId);
            Console.WriteLine(plant.Name);
            if (plant == null)
            {
                return BadRequest("Plant not found.");
            }
            plantWateredItem.Plant = plant;
            plant.PlantWateredItems.Add(plantWateredItem);
            
            _context.Plant.Update(plant);
            _context.PlantWateredItems.Add(plantWateredItem);
            _context.SaveChanges();

            //return CreatedAtAction("GetPlantWateredItem", new { id = plantWateredItem.Id }, plantWateredItem);
            return CreatedAtAction(nameof(GetPlantWateredItem), new { id = plantWateredItem.Id }, plantWateredItem);
        }

        // DELETE: api/PlantWateredItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantWateredItem(long id)
        {
            var plantWateredItem = await _context.PlantWateredItems.FindAsync(id);
            if (plantWateredItem == null)
            {
                return NotFound();
            }

            _context.PlantWateredItems.Remove(plantWateredItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantWateredItemExists(long id)
        {
            return _context.PlantWateredItems.Any(e => e.Id == id);
        }
    }
}
