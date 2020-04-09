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
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteRepositorio _repo;
        public IngredienteController()
        {
            _repo = new IngredienteRepositorio();
        }
        // GET: api/Ingrediente
        [HttpGet]
        public IEnumerable<Ingrediente> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Ingrediente/5
        [HttpGet("{id}", Name = "Get")]
        public Ingrediente Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Ingrediente
        [HttpPost]
        public Ingrediente Post([FromBody] Ingrediente ingrediente)
        {
            _repo.Incluir(ingrediente);
            return ingrediente;
        }

        // PUT: api/Ingrediente/5
        [HttpPut()]
        public Ingrediente Put(int id, [FromBody] Ingrediente ingrediente)
        {
            _repo.Alterar(ingrediente);
            return ingrediente;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Ingrediente> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
