using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        private readonly int maxNumero = 350;

        public List<int> Fibonacci()
        {
            int numero_anterior = 0;
            int numero_atual = 1;
            int numero_proximo = 1;
            List<int> sequencia = new List<int> { numero_anterior, numero_atual };

            while (numero_proximo <= maxNumero)
            {
                sequencia.Add(numero_proximo);
                numero_anterior = numero_atual;
                numero_atual = numero_proximo;
                numero_proximo = numero_atual + numero_anterior;
            }

            return sequencia;
        }

        public bool IsFibonacci(int numberToTest)
        {
            int numero_anterior = 0;
            int numero_atual = 1;
            int numero_proximo = 1;

            if (numberToTest == numero_anterior || numberToTest == numero_atual)
            {
                return true;
            }

            while (numero_proximo < numberToTest)
            {
                numero_anterior = numero_atual;
                numero_atual = numero_proximo;
                numero_proximo = numero_atual + numero_anterior;
            }

            return numberToTest == numero_proximo;
        }

    }
}
