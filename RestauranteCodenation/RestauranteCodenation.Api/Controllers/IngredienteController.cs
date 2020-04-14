using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Data.Repositorio;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteApplication _app;
        public IngredienteController(IIngredienteApplication app)
        {
            _app = app;
        }
        
        [HttpGet]
        public IEnumerable<IngredienteViewModel> Get()
        {
            return _app.SelecionarTodos();
        }
                
        [HttpGet("{id}")]
        public IngredienteViewModel Get(int id)
        {
            return _app.SelecionarPorId(id);
        }
                
        [HttpPost]
        public IngredienteViewModel Post([FromBody] IngredienteViewModel ingrediente)
        {
            _app.Incluir(ingrediente);
            return ingrediente;
        }

        [HttpPut]
        public IngredienteViewModel Put([FromBody] IngredienteViewModel ingrediente)
        {
            _app.Alterar(ingrediente);
            return ingrediente;
        }
                
        [HttpDelete("{id}")]
        public List<IngredienteViewModel> Delete(int id)
        {
            _app.Excluir(id);
            return _app.SelecionarTodos();
        }
    }
}
