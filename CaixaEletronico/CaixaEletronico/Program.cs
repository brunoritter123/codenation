using System;

namespace CaixaEletronico
{
    class Program
    {
        static Nota PerguntarNota()
        {
            Console.WriteLine("Digite o valor da nota: ");
            int.TryParse(Console.ReadLine(), out int valorNota);
            Console.WriteLine("");

            Console.WriteLine("Digite a moeda da nota: ");
            string moedaNota = Console.ReadLine();
            Console.WriteLine("");

            return new Nota(valorNota, moedaNota);
        }
        static void Main(string[] args)
        {
            var cofre = new Cofre();
            Nota novaNota;

            while (true)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Digite opção: 1=Incluir Nota, 2=Retirar Notas ou 3=Consultar Valor do Cofre");
                Console.ResetColor();
                int.TryParse(Console.ReadLine(), out int opcao);
                Console.WriteLine("");

                switch (opcao)
                {
                    case 1: // Incluir Nota
                        novaNota = PerguntarNota();
                        cofre.IncluirNota(novaNota);
                        break;

                    case 2: // Retirar Nota
                        novaNota = PerguntarNota();
                        Console.WriteLine("Quantidade de notas para retirar: ");
                        int.TryParse(Console.ReadLine(), out int quantidadeNotasRetirar);
                        Console.WriteLine("");
                        cofre.RetirarNotas(novaNota, quantidadeNotasRetirar);
                        break;

                    case 3:
                        var totalValorCofre = cofre.ConsultarValorDoCofre();
                        Console.WriteLine($"Total do cofre é: {totalValorCofre}");
                        break;

                    default:
                        Console.WriteLine("Opção não suportada:");
                        break;
                }
            }
        }
    }
}
