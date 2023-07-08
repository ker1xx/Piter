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
    public class LoyaltyСardController : ControllerBase
    {
        private readonly FuelContext _context;

        public LoyaltyСardController(FuelContext context)
        {
            _context = context;
        }

        // GET: api/LoyaltyСard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoyaltyСard>>> GetLoyaltyСards()
        {
          if (_context.LoyaltyСards == null)
          {
              return NotFound();
          }
            return await _context.LoyaltyСards.ToListAsync();
        }

        // GET: api/LoyaltyСard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoyaltyСard>> GetLoyaltyСard(int? id)
        {
          if (_context.LoyaltyСards == null)
          {
              return NotFound();
          }
            var loyaltyСard = await _context.LoyaltyСards.FindAsync(id);

            if (loyaltyСard == null)
            {
                return NotFound();
            }

            return loyaltyСard;
        }

        // PUT: api/LoyaltyСard/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoyaltyСard(int? id, LoyaltyСard loyaltyСard)
        {
            if (id != loyaltyСard.Id)
            {
                return BadRequest();
            }

            _context.Entry(loyaltyСard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoyaltyСardExists(id))
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

        // POST: api/LoyaltyСard
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoyaltyСard>> PostLoyaltyСard(LoyaltyСard loyaltyСard)
        {
          if (_context.LoyaltyСards == null)
          {
              return Problem("Entity set 'FuelContext.LoyaltyСards'  is null.");
          }
            _context.LoyaltyСards.Add(loyaltyСard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoyaltyСard", new { id = loyaltyСard.Id }, loyaltyСard);
        }

        // DELETE: api/LoyaltyСard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoyaltyСard(int? id)
        {
            if (_context.LoyaltyСards == null)
            {
                return NotFound();
            }
            var loyaltyСard = await _context.LoyaltyСards.FindAsync(id);
            if (loyaltyСard == null)
            {
                return NotFound();
            }

            _context.LoyaltyСards.Remove(loyaltyСard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoyaltyСardExists(int? id)
        {
            return (_context.LoyaltyСards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
