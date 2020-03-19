using System;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico
{
    class Gaveta
    {
        public Nota TipoNotaGaveta { get; }
        private Stack<Nota> _notas = new Stack<Nota>();

        public void IncluirNota(Nota nota)
        {
            _notas.Push(nota);
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
                Util.ConsoleErro($"Não existe notas suficientes de '{TipoNotaGaveta.Valor} {TipoNotaGaveta.Moeda}' para ser retirada.");
            }
            else
            {
                for (int i = 0; i < quantidade; i++)
                {
                    _notas.Pop();
                }
            }
        }
    }
}
