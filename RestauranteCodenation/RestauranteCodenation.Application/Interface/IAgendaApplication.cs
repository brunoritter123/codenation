using RestauranteCodenation.Application.ViewModel;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.Interface
{
    public interface IAgendaApplication
    {
        List<AgendaViewModel> SelecionarTodos();
        void Incluir(AgendaViewModel entity);
        void Alterar(AgendaViewModel entity);
        AgendaViewModel SelecionarPorId(int id);
        void Excluir(int id);
    }
}
