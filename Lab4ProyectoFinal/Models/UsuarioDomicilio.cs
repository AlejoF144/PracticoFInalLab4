

namespace Lab4ProyectoFinal.Models
{
    public class UsuarioDomicilio
    {
        public int UsuarioId { get; set; }
        public int DomicilioId { get; set; }
        public Usuario? Usuario { get; set; }
        public Domicilio? Domicilio { get; set; }
    }
}
