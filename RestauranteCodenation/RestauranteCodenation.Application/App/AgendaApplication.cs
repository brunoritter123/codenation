using AutoMapper;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.App
{
    public class AgendaApplication : IAgendaApplication
    {
        private readonly IAgendaRepositorio _repo;
        private readonly IMapper _mapper;
        public AgendaApplication(IAgendaRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Incluir(AgendaViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Agenda>(entity));
        }

        public void Alterar(AgendaViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Agenda>(entity));
        }

        public AgendaViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<AgendaViewModel>(_repo.SelecionarPorId(id));
        }

        public List<AgendaViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<AgendaViewModel>>(_repo.SelecionarTodos());
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }
    }
}

