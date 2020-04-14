using RestauranteCodenation.Application.ViewModel;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.Interface
{
    public interface ITipoPratoApplication
    {
        List<TipoPratoViewModel> SelecionarTodos();
        void Incluir(TipoPratoViewModel entity);
        void Alterar(TipoPratoViewModel entity);
        TipoPratoViewModel SelecionarPorId(int id);
        void Excluir(int id);
    }
}
