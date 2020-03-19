using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico
{
    class Cofre
    {
        private Dictionary<Nota, Gaveta> _gavetas = new Dictionary<Nota, Gaveta>();

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
            Gaveta gavetaNotas;

            if (!_gavetas.TryGetValue(tipoDeNotaDaGaveta, out gavetaNotas))
            {
                gavetaNotas = new Gaveta(tipoDeNotaDaGaveta);
                _gavetas.Add(tipoDeNotaDaGaveta, gavetaNotas);
            }

            return gavetaNotas;
        }

        public Dictionary<string, int> ConsultarValorDoCofre()
        {
            var totalPorMoeda = new Dictionary<string, int>();
            int totalGaveta;
            string tipoNotaGaveta;

            foreach (var gaveta in _gavetas)
            {
                totalGaveta = gaveta.Value.ConsultarValorDaGaveta();
                tipoNotaGaveta = gaveta.Value.TipoNotaGaveta.Moeda;

                if (!totalPorMoeda.TryAdd(tipoNotaGaveta, totalGaveta))
                {
                    totalPorMoeda[tipoNotaGaveta] += totalGaveta;
                }
            }

            return totalPorMoeda;
        }
    }
}
