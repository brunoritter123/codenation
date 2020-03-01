using System;

namespace Desafio_02_Criptografia_JC
{
    class Program
    {
        static void Main(string[] args)
        {
            var cesarCypher = new CesarCypher();

            Console.WriteLine(cesarCypher.Crypt("a ligeira raposa marrom saltou sobre o cachorro cansado"));
        }
    }
}
