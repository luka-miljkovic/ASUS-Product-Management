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
    public class DrzavaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper; 
        //private AsusMapper mapper = new AsusMapper();
        public DrzavaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Drzava
        [HttpGet]
        public async Task<ActionResult<List<DrzavaDTO>>> GetDrzave()
        {
            var Drzave = await unitOfWork.DrzavaRepository.GetAll();
            return Ok(Drzave);

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Drzava, DrzavaDTO>().ForMember(dest => dest.Gradovi, opt => opt.MapFrom(src => src.Gradovi.Select(x => new DrzavaDTO
            //    {
            //        IDDrzave = x.Drzava.IDDrzave
            //    }))).ReverseMap();
            //});
            //var mapper = config.CreateMapper();
            var drzavaDTOs = _mapper.Map<List<DrzavaDTO>>(Drzave);

            return Ok(drzavaDTOs);

        }

        // GET api/Drzava/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrzavaDTO>> Get(int id)
        {
            Drzava drzava = await unitOfWork.DrzavaRepository.FindById(id);

            var drzavaDTO = _mapper.Map<DrzavaDTO>(drzava);

            return Ok(drzavaDTO);
        }
    }
}
