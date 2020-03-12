namespace CaixaEletronico
{
    class Nota
    {
        public Nota(int valor, string moeda)
        {
            Valor = valor;
            Moeda = moeda;
        }

        public int Valor { get; set; }
        public string Moeda { get; set; }
    }
}
