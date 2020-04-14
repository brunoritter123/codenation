using RestauranteCodenation.Application.ViewModel;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.Interface
{
    public interface IPratoApplication
    {
        List<PratoViewModel> SelecionarTodos();
        void Incluir(PratoViewModel entity);
        void Alterar(PratoViewModel entity);
        PratoViewModel SelecionarPorId(int id);
        void Excluir(int id);
    }
}
