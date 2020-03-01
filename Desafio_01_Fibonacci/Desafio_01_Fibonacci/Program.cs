using System;
using System.Collections.Generic;

namespace Desafio_01_Fibonacci
{
    class Program
    {
        static List<int> Sequencia { get; } = GerarSequenciaFibonacci();

        static void Main(string[] args)
        {
            var sequencia = Fibonacci();

            foreach (var item in sequencia)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Número: {i}  é da sequencia: {IsFibonnaci(i)}");
            }
            Console.ReadLine();
        }

        static List<int> GerarSequenciaFibonacci()
        {
            int numero_anterior = 0;
            int numero_atual = 1;
            int numero_proximo = 1;
            List<int> sequencia = new List<int> { numero_anterior, numero_atual };

            while (numero_proximo <= 350)
            {
                sequencia.Add(numero_proximo);
                numero_anterior = numero_atual;
                numero_atual = numero_proximo;
                numero_proximo = numero_atual + numero_anterior;
            }

            return sequencia;
        }

        static List<int> Fibonacci()
        {
            return Sequencia;
        }

        static bool IsFibonnaci(int valor)
        {
            return Sequencia.Contains(valor);
        }
    }
}
