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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll([FromQuery]string accelerationName = null, [FromQuery]int? companyId = null)
        {
            if (accelerationName != null && !companyId.HasValue)
            {
                return Ok(_mapper.Map<List<UserDTO>>(_service.FindByAccelerationName(accelerationName)));
            }
            else if (companyId.HasValue && accelerationName is null)
            {
                return Ok(_mapper.Map<List<UserDTO>>(_service.FindByCompanyId(companyId.Value)));
            }
            else
                return NoContent();
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            return Ok(_mapper.Map<UserDTO>(_service.FindById(id)));
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            var user = _mapper.Map<User>(value);
            var userSave = _service.Save(user);
            var userMap = _mapper.Map<UserDTO>(userSave);
            return Ok(userMap);
        }   
    }
}
