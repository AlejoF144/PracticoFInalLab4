namespace Lab4ProyectoFinal.Models
{
    public class UsuarioTarjeta
    {
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int TarjetaId { get; set; }
        public MetodoDePago? Tarjeta { get; set; }
    }
}
