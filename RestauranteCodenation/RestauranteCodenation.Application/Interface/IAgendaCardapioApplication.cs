using RestauranteCodenation.Application.ViewModel;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.Interface
{
    public interface IAgendaCardapioApplication
    {
        List<AgendaCardapioViewModel> SelecionarTodos();
        void Incluir(AgendaCardapioViewModel entity);
        void Alterar(AgendaCardapioViewModel entity);
        AgendaCardapioViewModel SelecionarPorId(int id);
        void Excluir(int id);
    }
}
