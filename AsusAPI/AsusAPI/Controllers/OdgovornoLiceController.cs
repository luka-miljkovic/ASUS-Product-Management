using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Domain;

namespace AsusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdgovornoLiceController : ControllerBase
    {
        private readonly AsusContext _context;

        public OdgovornoLiceController(AsusContext context)
        {
            _context = context;
        }

        // GET: api/OdgovornoLice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OdgovornoLice>>> GetOdgovornaLica()
        {
            return await _context.OdgovornaLica.ToListAsync();
        }

        // GET: api/OdgovornoLice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OdgovornoLice>> GetOdgovornoLice(int id)
        {
            var odgovornoLice = await _context.OdgovornaLica.FindAsync(id);

            if (odgovornoLice == null)
            {
                return NotFound();
            }

            return odgovornoLice;
        }

        // PUT: api/OdgovornoLice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOdgovornoLice(int id, OdgovornoLice odgovornoLice)
        {
            if (id != odgovornoLice.OdgovornoLiceId)
            {
                return BadRequest();
            }

            _context.Entry(odgovornoLice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdgovornoLiceExists(id))
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

        // POST: api/OdgovornoLice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OdgovornoLice>> PostOdgovornoLice(OdgovornoLice odgovornoLice)
        {
            _context.OdgovornaLica.Add(odgovornoLice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOdgovornoLice", new { id = odgovornoLice.OdgovornoLiceId }, odgovornoLice);
        }

        // DELETE: api/OdgovornoLice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOdgovornoLice(int id)
        {
            var odgovornoLice = await _context.OdgovornaLica.FindAsync(id);
            if (odgovornoLice == null)
            {
                return NotFound();
            }

            _context.OdgovornaLica.Remove(odgovornoLice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OdgovornoLiceExists(int id)
        {
            return _context.OdgovornaLica.Any(e => e.OdgovornoLiceId == id);
        }
    }
}
