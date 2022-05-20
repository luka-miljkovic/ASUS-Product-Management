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
    public class DrzavaController : ControllerBase
    {
        private readonly AsusContext _context;

        public DrzavaController(AsusContext context)
        {
            _context = context;
        }

        // GET: api/Drzava
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drzava>>> GetDrzave()
        {
            return await _context.Drzave.ToListAsync();
        }

        // GET: api/Drzava/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drzava>> GetDrzava(int id)
        {
            var drzava = await _context.Drzave.FindAsync(id);

            if (drzava == null)
            {
                return NotFound();
            }

            return drzava;
        }

        // PUT: api/Drzava/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrzava(int id, Drzava drzava)
        {
            if (id != drzava.IDDrzave)
            {
                return BadRequest();
            }

            _context.Entry(drzava).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrzavaExists(id))
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

        // POST: api/Drzava
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drzava>> PostDrzava(Drzava drzava)
        {
            _context.Drzave.Add(drzava);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrzava", new { id = drzava.IDDrzave }, drzava);
        }

        // DELETE: api/Drzava/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrzava(int id)
        {
            var drzava = await _context.Drzave.FindAsync(id);
            if (drzava == null)
            {
                return NotFound();
            }

            _context.Drzave.Remove(drzava);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrzavaExists(int id)
        {
            return _context.Drzave.Any(e => e.IDDrzave == id);
        }
    }
}
