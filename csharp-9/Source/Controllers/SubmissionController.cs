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
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _service;
        private readonly IMapper _mapper;
        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/submission/higherScore
        [HttpGet("higherScore")]
        public ActionResult<decimal> GetHigherScore([FromQuery]int? challengeId = null)
        {
            if (challengeId.HasValue)
            {
                return Ok(_service.FindHigherScoreByChallengeId(challengeId.Value));
            }
            else
                return NoContent();
        }

        // GET api/submission
        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll([FromQuery]int? challengeId = null, [FromQuery]int? accelerationId = null)
        {
            if (challengeId.HasValue && accelerationId.HasValue)
            {
                var submission = _service.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value);
                return Ok(_mapper.Map<List<SubmissionDTO>>(submission));
            }
            else
                return NoContent();
        }

        // POST api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            var submission = _mapper.Map<Submission>(value);
            return Ok(_mapper.Map<SubmissionDTO>(_service.Save(submission)));
        }
    }
}
