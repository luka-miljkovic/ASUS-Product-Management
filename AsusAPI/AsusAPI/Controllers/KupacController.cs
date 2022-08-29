using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<KupacDTO>>> GetKupci()
        {
            var Kupci = await unitOfWork.KupacRepository.GetAll();
            var kupacDTOs = _mapper.Map<List<KupacDTO>>(Kupci);

            foreach(KupacDTO kupac in kupacDTOs)
            {
                Drzava d = await unitOfWork.DrzavaRepository.FindById(kupac.IDDrzave);
                kupac.Drzava = new DrzavaDTO
                {
                    IDDrzave = d.IDDrzave,
                    NazivDrzave = d.NazivDrzave
                };
            }
          

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void PutKupac([FromBody] KupacDTO kupacDTO)
        {

            Kupac k = new Kupac
            {
                PIB = kupacDTO.PIB,
                NazivKupca = kupacDTO.NazivKupca,
                UlicaBroj = kupacDTO.UlicaBroj,
                Grad = new Grad { PostanskiBroj = kupacDTO.Grad.PostanskiBroj, IDDrzave = kupacDTO.Grad.IDDrzave }
            };

            unitOfWork.KupacRepository.Update(k);
            unitOfWork.Commit();
        }

        // POST: api/Kupac
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostKupac(KupacDTO kupac)
        {
            var Kupci = await unitOfWork.KupacRepository.GetAll();
            foreach (var item in Kupci)
            {
                if(item.PIB == kupac.PIB)
                {
                    return BadRequest($"Kupac sa PIB-om {kupac.PIB} vec postoji u sistemu");
                }
            }
            Kupac k = new Kupac
            {
                PIB = kupac.PIB,
                NazivKupca = kupac.NazivKupca,
                UlicaBroj = kupac.UlicaBroj,
                Grad = new Grad { PostanskiBroj = kupac.Grad.PostanskiBroj, IDDrzave = kupac.Grad.IDDrzave }
            };

            unitOfWork.KupacRepository.Add(k);
            unitOfWork.Commit();
            return Ok();
        }

        // DELETE: api/Kupac/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void DeleteKupac(int id)
        {
            unitOfWork.KupacRepository.Delete(new Kupac { PIB = id });
            unitOfWork.Commit();
        }

        private bool KupacExists(int id)
        {
            return _context.Kupci.Any(e => e.PIB == id);
        }
    }
}
