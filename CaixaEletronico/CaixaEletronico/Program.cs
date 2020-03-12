using System;

namespace CaixaEletronico
{
    class Program
    {
        static Nota PerguntarNota()
        {
            Console.WriteLine("\nDigite o valor da nota: ");
            int.TryParse(Console.ReadLine(), out int valorNota);

            Console.WriteLine("\nDigite a moeda da nota: ");
            string moedaNota = Console.ReadLine();

            return new Nota(valorNota, moedaNota);
        }
        static void Main(string[] args)
        {
            //var nota100reais1 = new Nota(100, "reais");
            //var nota100reais2 = new Nota(100, "reais");
            //var nota100reais3 = new Nota(100, "reais");
            //var nota20reais1 = new Nota(20, "reais");
            //var nota20reais2 = new Nota(20, "reais");
            //var nota20reais3 = new Nota(20, "reais");
            var cofre = new Cofre();

            //cofre.IncluirNotas(nota100reais1);
            //cofre.IncluirNotas(nota100reais2);
            //cofre.IncluirNotas(nota100reais3);
            //cofre.IncluirNotas(nota20reais1);
            //cofre.IncluirNotas(nota20reais2);
            //cofre.IncluirNotas(nota20reais3);

            //int qtdNotas = cofre.ConsultarValorDoCofre();

            //Console.WriteLine($"Quantidade notas: {qtdNotas}");
            //Console.ReadLine();

            Nota novaNota;


            while (true)
            {
                Console.WriteLine("\nDigite opção: 1=Incluir Nota, 2=Retirar Notas ou 3=Consultar Valor do Cofre");
                int.TryParse(Console.ReadLine(), out int opcao);

                switch (opcao)
                {
                    case 1: // Incluir Nota
                        novaNota = PerguntarNota();
                        cofre.IncluirNotas(novaNota);
                        break;

                    case 2: // Retirar Nota

                        novaNota = PerguntarNota();
                        Console.WriteLine("\nQuantidade de notas para retirar: ");
                        int.TryParse(Console.ReadLine(), out int quantidadeNotasRetirar);
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
