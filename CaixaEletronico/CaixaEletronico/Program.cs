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

        static void IncluirNota(Cofre cofre)
        {
            var nota = PerguntarNota();
            cofre.IncluirNota(nota);
        }

        static void RetirarNota(Cofre cofre)
        {
            var nota = PerguntarNota();
            Console.WriteLine("Quantidade de notas para retirar: ");
            int.TryParse(Console.ReadLine(), out int quantidadeNotasRetirar);
            Console.WriteLine("");
            cofre.RetirarNotas(nota, quantidadeNotasRetirar);
        }
        static void TotalDoCofre(Cofre cofre)
        {
            var totalValorCofre = cofre.ConsultarValorDoCofre();
            Console.WriteLine("Total do cofre é: ");
            foreach (var totalPorMoeda in totalValorCofre)
            {
                Console.WriteLine($"{totalPorMoeda.Value} - {totalPorMoeda.Key}");
            }
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            var cofre = new Cofre();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Digite opção: 1=Incluir Nota, 2=Retirar Notas ou 3=Consultar Valor do Cofre");
                Console.ResetColor();
                int.TryParse(Console.ReadLine(), out int opcao);
                Console.WriteLine("");

                switch (opcao)
                {
                    case 1:
                        IncluirNota(cofre);
                        break;

                    case 2:
                        RetirarNota(cofre);
                        break;

                    case 3:
                        TotalDoCofre(cofre);
                        break;

                    default:
                        Util.ConsoleErro("Opção não suportada:");
                        break;
                }
            }
        }
    }
}
