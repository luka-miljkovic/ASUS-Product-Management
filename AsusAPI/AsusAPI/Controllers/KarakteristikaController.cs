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
    public class KarakteristikaController : ControllerBase
    {
        private readonly AsusContext _context;

        public KarakteristikaController(AsusContext context)
        {
            _context = context;
        }

        // GET: api/Karakteristika
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Karakteristika>>> GetKarakteristike()
        {
            return await _context.Karakteristike.ToListAsync();
        }

        // GET: api/Karakteristika/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Karakteristika>> GetKarakteristika(int id)
        {
            var karakteristika = await _context.Karakteristike.FindAsync(id);

            if (karakteristika == null)
            {
                return NotFound();
            }

            return karakteristika;
        }

        // PUT: api/Karakteristika/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKarakteristika(int id, Karakteristika karakteristika)
        {
            if (id != karakteristika.IDKarakteristike)
            {
                return BadRequest();
            }

            _context.Entry(karakteristika).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KarakteristikaExists(id))
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

        // POST: api/Karakteristika
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Karakteristika>> PostKarakteristika(Karakteristika karakteristika)
        {
            _context.Karakteristike.Add(karakteristika);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKarakteristika", new { id = karakteristika.IDKarakteristike }, karakteristika);
        }

        // DELETE: api/Karakteristika/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKarakteristika(int id)
        {
            var karakteristika = await _context.Karakteristike.FindAsync(id);
            if (karakteristika == null)
            {
                return NotFound();
            }

            _context.Karakteristike.Remove(karakteristika);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KarakteristikaExists(int id)
        {
            return _context.Karakteristike.Any(e => e.IDKarakteristike == id);
        }
    }
}
