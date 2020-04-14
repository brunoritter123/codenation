using RestauranteCodenation.Application.ViewModel;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.Interface
{
    public interface ICardapioApplication
    {
        List<CardapioViewModel> SelecionarTodos();
        void Incluir(CardapioViewModel entity);
        void Alterar(CardapioViewModel entity);
        CardapioViewModel SelecionarPorId(int id);
        void Excluir(int id);
    }
}
