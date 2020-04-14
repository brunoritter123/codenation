using AutoMapper;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.App
{
    public class PratoApplication : IPratoApplication
    {
        private readonly IPratoRepositorio _repo;
        private readonly IMapper _mapper;
        public PratoApplication(IPratoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Incluir(PratoViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Prato>(entity));
        }

        public void Alterar(PratoViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Prato>(entity));
        }

        public PratoViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<PratoViewModel>(_repo.SelecionarPorId(id));
        }

        public List<PratoViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<PratoViewModel>>(_repo.SelecionarTodos());
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }
    }
}

