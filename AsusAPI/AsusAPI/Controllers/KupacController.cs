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
    public class KupacController : ControllerBase
    {
        private readonly AsusContext _context;

        public KupacController(AsusContext context)
        {
            _context = context;
        }

        // GET: api/Kupac
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kupac>>> GetKupci()
        {
            return await _context.Kupci.ToListAsync();
        }

        // GET: api/Kupac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kupac>> GetKupac(int id)
        {
            var kupac = await _context.Kupci.FindAsync(id);

            if (kupac == null)
            {
                return NotFound();
            }

            return kupac;
        }

        // PUT: api/Kupac/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKupac(int id, Kupac kupac)
        {
            if (id != kupac.PIB)
            {
                return BadRequest();
            }

            _context.Entry(kupac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KupacExists(id))
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

        // POST: api/Kupac
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kupac>> PostKupac(Kupac kupac)
        {
            _context.Kupci.Add(kupac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKupac", new { id = kupac.PIB }, kupac);
        }

        // DELETE: api/Kupac/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKupac(int id)
        {
            var kupac = await _context.Kupci.FindAsync(id);
            if (kupac == null)
            {
                return NotFound();
            }

            _context.Kupci.Remove(kupac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KupacExists(int id)
        {
            return _context.Kupci.Any(e => e.PIB == id);
        }
    }
}
