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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;
        public CandidateController(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/candidate
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll([FromQuery]int? companyId = null, [FromQuery]int? accelerationId = null)
        {
            if (companyId.HasValue && !accelerationId.HasValue)
            {
                return Ok(_mapper.Map<List<CandidateDTO>>(_service.FindByCompanyId(companyId.Value)));
            }
            else if (accelerationId.HasValue && !companyId.HasValue)
            {
                return Ok(_mapper.Map<List<CandidateDTO>>(_service.FindByAccelerationId(accelerationId.Value)));
            }
            else
                return NoContent();
        }

        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            return Ok(_mapper.Map<CandidateDTO>(_service.FindById(userId, accelerationId, companyId)));
        }

        // POST api/candidate
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            var candidate = _mapper.Map<Candidate>(value);
            return Ok(_mapper.Map<CandidateDTO>(_service.Save(candidate)));
        }
    }
}
