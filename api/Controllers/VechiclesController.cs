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
    public class VechiclesController : ControllerBase
    {
        private readonly FuelContext _context;

        public VechiclesController(FuelContext context)
        {
            _context = context;
        }

        // GET: api/Vechicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vechicle>>> GetVechicles()
        {
          if (_context.Vechicles == null)
          {
              return NotFound();
          }
            return await _context.Vechicles.ToListAsync();
        }

        // GET: api/Vechicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vechicle>> GetVechicle(int? id)
        {
          if (_context.Vechicles == null)
          {
              return NotFound();
          }
            var vechicle = await _context.Vechicles.FindAsync(id);

            if (vechicle == null)
            {
                return NotFound();
            }

            return vechicle;
        }

        // PUT: api/Vechicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVechicle(int? id, Vechicle vechicle)
        {
            if (id != vechicle.Id)
            {
                return BadRequest();
            }

            _context.Entry(vechicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VechicleExists(id))
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

        // POST: api/Vechicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vechicle>> PostVechicle(Vechicle vechicle)
        {
          if (_context.Vechicles == null)
          {
              return Problem("Entity set 'FuelContext.Vechicles'  is null.");
          }
            _context.Vechicles.Add(vechicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVechicle", new { id = vechicle.Id }, vechicle);
        }

        // DELETE: api/Vechicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVechicle(int? id)
        {
            if (_context.Vechicles == null)
            {
                return NotFound();
            }
            var vechicle = await _context.Vechicles.FindAsync(id);
            if (vechicle == null)
            {
                return NotFound();
            }

            _context.Vechicles.Remove(vechicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VechicleExists(int? id)
        {
            return (_context.Vechicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
