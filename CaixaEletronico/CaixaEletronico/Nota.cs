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

        public override bool Equals(object obj)
        {
            var outraNota = obj as Nota;

            if (outraNota == null)
            {
                return false;
            }
            return Valor == outraNota.Valor && Moeda == outraNota.Moeda;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            string hashCode = Valor.ToString() + Moeda;
            return hashCode.GetHashCode();
        }
    }
}
