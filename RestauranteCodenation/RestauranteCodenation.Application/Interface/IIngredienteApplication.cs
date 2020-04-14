using RestauranteCodenation.Application.ViewModel;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.Interface
{
    public interface IIngredienteApplication
    {
        List<IngredienteViewModel> SelecionarTodos();
        void Incluir(IngredienteViewModel entity);
        void Alterar(IngredienteViewModel entity);
        IngredienteViewModel SelecionarPorId(int id);
        void Excluir(int id);
    }
}
