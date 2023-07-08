using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GasStationsController : ControllerBase
    {
        private readonly FuelContext _context;

        public GasStationsController(FuelContext context)
        {
            _context = context;
        }

        // GET: api/GasStations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GasStation>>> GetGasStations()
        {
          if (_context.GasStations == null)
          {
              return NotFound();
          }
            return await _context.GasStations.ToListAsync();
        }

        // GET: api/GasStations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GasStation>> GetGasStation(int? id)
        {
          if (_context.GasStations == null)
          {
              return NotFound();
          }
            var gasStation = await _context.GasStations.FindAsync(id);

            if (gasStation == null)
            {
                return NotFound();
            }

            return gasStation;
        }

        // PUT: api/GasStations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGasStation(int? id, GasStation gasStation)
        {
            if (id != gasStation.Id)
            {
                return BadRequest();
            }

            _context.Entry(gasStation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GasStationExists(id))
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

        // POST: api/GasStations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GasStation>> PostGasStation(GasStation gasStation)
        {
          if (_context.GasStations == null)
          {
              return Problem("Entity set 'FuelContext.GasStations'  is null.");
          }
            _context.GasStations.Add(gasStation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGasStation", new { id = gasStation.Id }, gasStation);
        }

        // DELETE: api/GasStations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGasStation(int? id)
        {
            if (_context.GasStations == null)
            {
                return NotFound();
            }
            var gasStation = await _context.GasStations.FindAsync(id);
            if (gasStation == null)
            {
                return NotFound();
            }

            _context.GasStations.Remove(gasStation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GasStationExists(int? id)
        {
            return (_context.GasStations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
