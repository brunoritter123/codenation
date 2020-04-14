﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : ControllerBase
    {
        private readonly IPratoApplication _app;
        public PratoController(IPratoApplication app)
        {
            _app = app;
        }
               
        [HttpGet]
        public IEnumerable<PratoViewModel> Get()
        {
            return _app.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public PratoViewModel Get(int id)
        {
            return _app.SelecionarPorId(id);
        }

        [HttpPost]
        public PratoViewModel Post([FromBody] PratoViewModel prato)
        {
            _app.Incluir(prato);
            return prato;
        }

        [HttpPut]
        public PratoViewModel Put([FromBody] PratoViewModel prato)
        {
            _app.Alterar(prato);
            return prato;
        }

        [HttpDelete("{id}")]
        public IEnumerable<PratoViewModel> Delete(int id)
        {
            _app.Excluir(id);
            return _app.SelecionarTodos();
        }
    }
}
