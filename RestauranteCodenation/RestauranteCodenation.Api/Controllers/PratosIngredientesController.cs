using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Data.Repositorio;
using RestauranteCodenation.Domain;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratosIngredientesController : ControllerBase
    {
        private readonly PratosIngredientesRepositorio _repo;
        public PratosIngredientesController()
        {
            _repo = new PratosIngredientesRepositorio();
        }
        // GET: api/PratosIngredientes
        [HttpGet]
        public IEnumerable<PratosIngredientes> Get()
        {
            return _repo.SelecionarCompleto();
        }

        // GET: api/PratosIngredientes/5
        [HttpGet("{id}")]
        public PratosIngredientes Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/PratosIngredientes
        [HttpPost]
        public PratosIngredientes Post([FromBody] PratosIngredientes pratosIngredientes)
        {
            _repo.Incluir(pratosIngredientes);
            return pratosIngredientes;
        }

        // PUT: api/PratosIngredientes/5
        [HttpPut()]
        public PratosIngredientes Put([FromBody] PratosIngredientes pratosIngredientes)
        {
            _repo.Alterar(pratosIngredientes);
            return pratosIngredientes;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<PratosIngredientes> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
