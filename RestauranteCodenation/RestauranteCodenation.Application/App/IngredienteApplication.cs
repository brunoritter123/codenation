using AutoMapper;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.App
{
    public class IngredienteApplication : IIngredienteApplication
    {
        private readonly IIngredienteRepositorio _repo;
        private readonly IMapper _mapper;
        public IngredienteApplication(IIngredienteRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Incluir(IngredienteViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Ingrediente>(entity));
        }

        public void Alterar(IngredienteViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Ingrediente>(entity));
        }

        public IngredienteViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<IngredienteViewModel>(_repo.SelecionarPorId(id));
        }

        public List<IngredienteViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<IngredienteViewModel>>(_repo.SelecionarTodos());
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }
    }
}

