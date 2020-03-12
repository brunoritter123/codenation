using System;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico
{
    class Gaveta
    {
        public Nota TipoNotaGaveta { get; }
        private List<Nota> _notas = new List<Nota>();

        public void IncluirNota(Nota nota)
        {
            _notas.Add(nota);
        }

        public Gaveta(Nota tipoNotaGaveta)
        {
            var novaNota = new Nota(tipoNotaGaveta.Valor, tipoNotaGaveta.Moeda);
            TipoNotaGaveta = novaNota;
        }

        public int ConsultarQuantidadeNotas()
        {
            return _notas.Count;
        }

        public int ConsultarValorDaGaveta()
        {
            return _notas.Sum(nota => nota.Valor);
        }

        internal void RetirarNotas(int quantidade)
        {
            if (ConsultarQuantidadeNotas() < quantidade)
            {
                Console.WriteLine("Não existe notas suficientes para ser retiradas");
            }
            else
            {
                _notas.RemoveRange(0, quantidade);
            }
        }
    }
}
