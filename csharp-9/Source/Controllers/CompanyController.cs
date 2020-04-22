using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll([FromQuery]int? accelerationId = null, [FromQuery]int? userId = null)
        {
            if (accelerationId.HasValue && !userId.HasValue)
            {
                return Ok(_mapper.Map<List<CompanyDTO>>(_service.FindByAccelerationId(accelerationId.Value)));
            }
            else if (userId.HasValue && !accelerationId.HasValue)
            {
                return Ok(_mapper.Map<List<CompanyDTO>>(_service.FindByUserId(userId.Value)));
            }
            else
                return NoContent();
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            return Ok(_mapper.Map<CompanyDTO>(_service.FindById(id)));
        }

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            var company = _mapper.Map<Company>(value);
            return Ok(_mapper.Map<CompanyDTO>(_service.Save(company)));
        }
    }
}
