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
    public class ProizvodController : ControllerBase
    {
        private readonly AsusContext _context;

        public ProizvodController(AsusContext context)
        {
            _context = context;
        }

        // GET: api/Proizvod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proizvod>>> GetProizvodi()
        {
            return await _context.Proizvodi.ToListAsync();
        }

        // GET: api/Proizvod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proizvod>> GetProizvod(int id)
        {
            var proizvod = await _context.Proizvodi.FindAsync(id);

            if (proizvod == null)
            {
                return NotFound();
            }

            return proizvod;
        }

        // PUT: api/Proizvod/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProizvod(int id, Proizvod proizvod)
        {
            if (id != proizvod.SifraProizvoda)
            {
                return BadRequest();
            }

            _context.Entry(proizvod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProizvodExists(id))
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

        // POST: api/Proizvod
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proizvod>> PostProizvod(Proizvod proizvod)
        {
            _context.Proizvodi.Add(proizvod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProizvod", new { id = proizvod.SifraProizvoda }, proizvod);
        }

        // DELETE: api/Proizvod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProizvod(int id)
        {
            var proizvod = await _context.Proizvodi.FindAsync(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            _context.Proizvodi.Remove(proizvod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProizvodExists(int id)
        {
            return _context.Proizvodi.Any(e => e.SifraProizvoda == id);
        }
    }
}
