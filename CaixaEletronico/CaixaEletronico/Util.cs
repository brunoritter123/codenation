using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico
{
    public static class Util
    {
        public static void ConsoleErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
