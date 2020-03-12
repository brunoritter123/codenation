using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge
{

    public class Math
    {
        private readonly int _numeroMaximo = 350;

        /// <summary>
        /// Gerar um lista com a sequência Fibonacci até o número <see cref="_numeroMaximo"/>" de 350
        /// </summary>
        /// <returns></returns>
        public List<int> Fibonacci()
        {
            return GerarListaFibonacci(_numeroMaximo);
        }

        /// <summary>
        /// Verifica se um número até <see cref="_numeroMaximo"/>" de 350 pertencia a sequência Fibonacci
        /// </summary>
        /// <param name="numberToTest">Número para testar se pertencia a sequência Fibonacci</param>
        /// <returns></returns>
        public bool IsFibonacci(int numberToTest)
        {
            if (numberToTest > _numeroMaximo || numberToTest < 0)
                return false;

            return GerarListaFibonacci(numberToTest).Last() == numberToTest;
        }

        private List<int> GerarListaFibonacci(int numeroMaximo)
        {
            int proximoNumero = 1;
            List<int> sequencia = new List<int> { 0 };

            while (proximoNumero <= numeroMaximo)
            {
                sequencia.Add(proximoNumero);
                proximoNumero = sequencia.Last() + sequencia.ElementAt(sequencia.Count - 2);
            }

            return sequencia;
        }
    }
}
