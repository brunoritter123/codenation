using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;
using System.Collections.Generic;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratosIngredientesController : ControllerBase
    {
        private readonly IPratosIngredientesApplication _app;
        public PratosIngredientesController(IPratosIngredientesApplication app)
        {
            _app = app;
        }

        [HttpGet]
        public IEnumerable<PratosIngredientesViewModel> Get()
        {
            return _app.SelecionarCompleto();
        }

        [HttpGet("{id}")]
        public PratosIngredientesViewModel Get(int id)
        {
            return _app.SelecionarPorId(id);
        }

        [HttpPost]
        public PratosIngredientesViewModel Post([FromBody] PratosIngredientesViewModel pratosIngredientes)
        {
            _app.Incluir(pratosIngredientes);
            return pratosIngredientes;
        }

        [HttpPut]
        public PratosIngredientesViewModel Put([FromBody] PratosIngredientesViewModel pratosIngredientes)
        {
            _app.Alterar(pratosIngredientes);
            return pratosIngredientes;
        }

        [HttpDelete("{id}")]
        public List<PratosIngredientesViewModel> Delete(int id)
        {
            _app.Excluir(id);
            return _app.SelecionarTodos();
        }
    }
}
