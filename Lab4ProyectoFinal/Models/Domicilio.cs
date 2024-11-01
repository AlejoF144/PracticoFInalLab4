namespace Lab4ProyectoFinal.Models
{
    public class Domicilio
    {
        public int Id { get; set; }
        public string? Calle { get; set; }
        public List<UsuarioDomicilio>? Usuarios { get; set; }

    }
}
