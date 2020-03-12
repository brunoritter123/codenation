using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico
{
    class Cofre
    {
        private List<Gaveta> _gavetas = new List<Gaveta>();

        public void IncluirNota(Nota nota)
        {
            var gavetaNotas = BuscarGaveta(nota);
            gavetaNotas.IncluirNota(nota);
        }

        public void RetirarNotas(Nota nota, int quantidade)
        {
            var gavetaEncontrada = BuscarGaveta(nota);
            gavetaEncontrada.RetirarNotas(quantidade);

        }

        private Gaveta BuscarGaveta(Nota tipoDeNotaDaGaveta)
        {
            var gavetaNotas = _gavetas.Find(gaveta => gaveta.TipoNotaGaveta.Equals(tipoDeNotaDaGaveta));
            if (gavetaNotas is null)
            {
                gavetaNotas = new Gaveta(tipoDeNotaDaGaveta);
                _gavetas.Add(gavetaNotas);
            }

            return gavetaNotas;
        }

        public int ConsultarValorDoCofre()
        {
            return _gavetas.Sum(gaveta => gaveta.ConsultarValorDaGaveta());
        }
    }
}
