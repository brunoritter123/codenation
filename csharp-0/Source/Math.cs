using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        private readonly int _numeroMaximo = 350;

        public List<int> Fibonacci()
        {
            return GerarListaFibonacci(_numeroMaximo);
        }

        public bool IsFibonacci(int numberToTest)
        {
            if (numberToTest > _numeroMaximo)
            {
                return false;
            }

            var gerarListaFibonacci = GerarListaFibonacci(numberToTest);
            return gerarListaFibonacci[gerarListaFibonacci.Count - 1] == numberToTest;
        }

        private List<int> GerarListaFibonacci(int numeroMaximo)
        {
            int numeroAnterior = 0;
            int proximoNumero = 1;
            List<int> sequencia = new List<int> { numeroAnterior };

            while (proximoNumero <= numeroMaximo)
            {
                sequencia.Add(proximoNumero);
                proximoNumero = proximoNumero + numeroAnterior;
                numeroAnterior = proximoNumero - numeroAnterior;
            }

            return sequencia;
        }
    }
}
