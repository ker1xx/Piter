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
    public class CameraLoadsController : ControllerBase
    {
        private readonly FuelContext _context;

        public CameraLoadsController(FuelContext context)
        {
            _context = context;
        }

        // GET: api/CameraLoads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CameraLoad>>> GetCameraLoads()
        {
          if (_context.CameraLoads == null)
          {
              return NotFound();
          }
            return await _context.CameraLoads.ToListAsync();
        }

        // GET: api/CameraLoads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CameraLoad>> GetCameraLoad(int? id)
        {
          if (_context.CameraLoads == null)
          {
              return NotFound();
          }
            var cameraLoad = await _context.CameraLoads.FindAsync(id);

            if (cameraLoad == null)
            {
                return NotFound();
            }

            return cameraLoad;
        }

        // PUT: api/CameraLoads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCameraLoad(int? id, CameraLoad cameraLoad)
        {
            if (id != cameraLoad.Id)
            {
                return BadRequest();
            }

            _context.Entry(cameraLoad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CameraLoadExists(id))
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

        // POST: api/CameraLoads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CameraLoad>> PostCameraLoad(CameraLoad cameraLoad)
        {
          if (_context.CameraLoads == null)
          {
              return Problem("Entity set 'FuelContext.CameraLoads'  is null.");
          }
            _context.CameraLoads.Add(cameraLoad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCameraLoad", new { id = cameraLoad.Id }, cameraLoad);
        }

        // DELETE: api/CameraLoads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCameraLoad(int? id)
        {
            if (_context.CameraLoads == null)
            {
                return NotFound();
            }
            var cameraLoad = await _context.CameraLoads.FindAsync(id);
            if (cameraLoad == null)
            {
                return NotFound();
            }

            _context.CameraLoads.Remove(cameraLoad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CameraLoadExists(int? id)
        {
            return (_context.CameraLoads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
