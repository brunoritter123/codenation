using AutoMapper;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.App
{
    public class CardapioApplication : ICardapioApplication
    {
        private readonly ICardapioRepositorio _repo;
        private readonly IMapper _mapper;
        public CardapioApplication(ICardapioRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Incluir(CardapioViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Cardapio>(entity));
        }

        public void Alterar(CardapioViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Cardapio>(entity));
        }

        public CardapioViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<CardapioViewModel>(_repo.SelecionarPorId(id));
        }

        public List<CardapioViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<CardapioViewModel>>(_repo.SelecionarTodos());
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }
    }
}

