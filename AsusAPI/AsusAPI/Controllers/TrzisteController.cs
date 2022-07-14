using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataTransferObject;
using Model.Domain;

namespace AsusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrzisteController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private AsusMapper mapper = new AsusMapper();
        private readonly AsusContext _context;

        public TrzisteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // GET: api/Trziste
        [HttpGet]
        public async Task<ActionResult<List<Trziste>>> GetTrzista()
        {
            var Trzista = await unitOfWork.TrzisteRepository.GetAll();
            List<TrzisteDTO> trzisteDTOs = new List<TrzisteDTO>();

            //var config = new MapperConfiguration(mc=>mc.CreateMap<Trziste, TrzisteDTO>)
            //return await _context.Trzista.ToListAsync();

            return Trzista;
        }

        // GET: api/Trziste/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trziste>> GetTrziste(int id)
        {
            var trziste = await _context.Trzista.FindAsync(id);

            if (trziste == null)
            {
                return NotFound();
            }

            return trziste;
        }

        // PUT: api/Trziste/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrziste(int id, Trziste trziste)
        {
            if (id != trziste.SifraTrzista)
            {
                return BadRequest();
            }

            _context.Entry(trziste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrzisteExists(id))
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

        // POST: api/Trziste
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trziste>> PostTrziste(Trziste trziste)
        {
            _context.Trzista.Add(trziste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrziste", new { id = trziste.SifraTrzista }, trziste);
        }

        // DELETE: api/Trziste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrziste(int id)
        {
            var trziste = await _context.Trzista.FindAsync(id);
            if (trziste == null)
            {
                return NotFound();
            }

            _context.Trzista.Remove(trziste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrzisteExists(int id)
        {
            return _context.Trzista.Any(e => e.SifraTrzista == id);
        }
    }
}
