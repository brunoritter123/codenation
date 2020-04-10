using Microsoft.EntityFrameworkCore;
using RestauranteCodenation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteCodenation.Data.Repositorio
{
    public class PratosIngredientesRepositorio : RepositorioBase<PratosIngredientes>
    {
        public List<PratosIngredientes> SelecionarCompleto()
        {
            return _contexto
                .PratosIngredientes
                .Include(x => x.Ingrediente)
                .Include(x => x.Prato)
                .ToList();
        }
    }        
}
