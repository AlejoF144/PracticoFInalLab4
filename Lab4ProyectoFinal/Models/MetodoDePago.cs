namespace Lab4ProyectoFinal.Models
{
    public class MetodoDePago
    {
        public int Id { get; set; }
        public int NumeroDeTarjeta { get; set; }
        public string? MarcaDeTarjeta { get; set; }
        public string? Expiracion { get; set; }
        public List<Usuario>? Usuarios { get; set; }
    }
}


