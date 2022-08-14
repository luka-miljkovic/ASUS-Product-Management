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
    public class GradController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IMapper _mapper;

        public GradController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // GET: api/Grad
        [HttpGet]
        public async Task<ActionResult<List<GradDTO>>> GetGradovi()
        {
            var Gradovi = await unitOfWork.GradRepository.GetAll();
            var gradDTOs = _mapper.Map<List<GradDTO>>(Gradovi);

            return Ok(gradDTOs);
        }

        // GET: api/Grad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GradDTO>>> GetGradoviByCond(int id)
        {
            var Gradovi = await unitOfWork.GradRepository.GetAllWithCondition(id);
            var gradDTOs = _mapper.Map<List<GradDTO>>(Gradovi);

            return Ok(gradDTOs);
        }

    }
}
