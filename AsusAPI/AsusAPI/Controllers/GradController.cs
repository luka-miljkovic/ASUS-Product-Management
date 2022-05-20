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
    public class GradController : ControllerBase
    {
        private readonly AsusContext _context;

        public GradController(AsusContext context)
        {
            _context = context;
        }

        // GET: api/Grad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grad>>> GetGradovi()
        {
            return await _context.Gradovi.ToListAsync();
        }

        // GET: api/Grad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grad>> GetGrad(int id)
        {
            var grad = await _context.Gradovi.FindAsync(id);

            if (grad == null)
            {
                return NotFound();
            }

            return grad;
        }

        // PUT: api/Grad/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrad(int id, Grad grad)
        {
            if (id != grad.PostanskiBroj)
            {
                return BadRequest();
            }

            _context.Entry(grad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradExists(id))
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

        // POST: api/Grad
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grad>> PostGrad(Grad grad)
        {
            _context.Gradovi.Add(grad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GradExists(grad.PostanskiBroj))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGrad", new { id = grad.PostanskiBroj }, grad);
        }

        // DELETE: api/Grad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrad(int id)
        {
            var grad = await _context.Gradovi.FindAsync(id);
            if (grad == null)
            {
                return NotFound();
            }

            _context.Gradovi.Remove(grad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradExists(int id)
        {
            return _context.Gradovi.Any(e => e.PostanskiBroj == id);
        }
    }
}
