namespace RestauranteCodenation.Application.ViewModel
{
    public class PratosIngredientesViewModel
    {
        public int Id { get; set; }
        public int IdPrato { get; set; }
        public PratoViewModel Prato { get; set; }
        public int IdIngrediente { get; set; }
        public IngredienteViewModel Ingrediente { get; set; }
    }
}
