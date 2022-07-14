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
    public class KupacController : ControllerBase
    {
        private readonly AsusContext _context;
        private readonly IUnitOfWork unitOfWork;
        private IMapper _mapper;

        public KupacController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Kupac
        [HttpGet]
        public async Task<ActionResult<List<KupacDTO>>> GetKupci()
        {
            var Kupci = await unitOfWork.KupacRepository.GetAll();
            var kupacDTOs = _mapper.Map<List<KupacDTO>>(Kupci);

            return Ok(kupacDTOs);

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
        public void PostKupac(KupacDTO kupac)
        {
            Kupac k = new Kupac
            {
                PIB = kupac.PIB,
                NazivKupca = kupac.NazivKupca,
                UlicaBroj = kupac.UlicaBroj,
                Grad = new Grad { PostanskiBroj = kupac.Grad.PostanskiBroj, IDDrzave = kupac.Grad.IDDrzave }
            };

            unitOfWork.KupacRepository.Add(k);
            unitOfWork.Commit();
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
