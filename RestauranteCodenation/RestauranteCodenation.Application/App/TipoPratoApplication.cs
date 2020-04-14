﻿using AutoMapper;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.App
{
    public class TipoPratoApplication : ITipoPratoApplication
    {
        private readonly ITipoPratoRepositorio _repo;
        private readonly IMapper _mapper;
        public TipoPratoApplication(ITipoPratoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Incluir(TipoPratoViewModel entity)
        {
            _repo.Incluir(_mapper.Map<TipoPrato>(entity));
        }

        public void Alterar(TipoPratoViewModel entity)
        {
            _repo.Alterar(_mapper.Map<TipoPrato>(entity));
        }

        public TipoPratoViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<TipoPratoViewModel>(_repo.SelecionarPorId(id));
        }

        public List<TipoPratoViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<TipoPratoViewModel>>(_repo.SelecionarTodos());
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }
    }
}

