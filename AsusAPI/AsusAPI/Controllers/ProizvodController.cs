﻿using System;
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
    public class ProizvodController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        private readonly AsusContext _context;

        public ProizvodController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Proizvod
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<ProizvodDTO>>> GetProizvodi()
        {
            var proizvodi = await unitOfWork.ProizvodRepository.GetAll();
            var proizvodDTOs = mapper.Map<List<ProizvodDTO>>(proizvodi);

            return Ok(proizvodDTOs);
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
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void PutProizvod(ProizvodDTO proizvod)
        {
            Proizvod p = mapper.Map<Proizvod>(proizvod);

            unitOfWork.ProizvodRepository.Update(p);
            unitOfWork.Commit();
        }

        // POST: api/Proizvod
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostProizvod(ProizvodDTO proizvod)
        {
            var proizvodi = await unitOfWork.ProizvodRepository.GetAll();
            foreach (var item in proizvodi)
            {
                if (item.SifraProizvoda == proizvod.SifraProizvoda)
                {
                    return BadRequest($"Proizvod sa sifrom {proizvod.SifraProizvoda} vec postoji u sistemu");
                }
            }
            Proizvod p = mapper.Map<Proizvod>(proizvod);

            try
            {
                unitOfWork.ProizvodRepository.Add(p);
                unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // DELETE: api/Proizvod/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void DeleteProizvod(int id)
        {
            unitOfWork.ProizvodRepository.Delete(new Proizvod { SifraProizvoda = id });
            unitOfWork.Commit();
        }

        private bool ProizvodExists(int id)
        {
            return _context.Proizvodi.Any(e => e.SifraProizvoda == id);
        }
    }
}
