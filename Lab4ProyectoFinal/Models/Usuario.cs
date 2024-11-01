using Microsoft.AspNetCore.Identity;

namespace Lab4ProyectoFinal.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Nivel { get; set; }
        public bool Estado { get; set; }
        public string? ImagenCarpeta { get; set; }

        public int TarjetaId { get; set; }
    
        public List<UsuarioTarjeta>? UsuarioTarjeta { get; set; }

        public int DomicilioId { get; set; }
        public List<UsuarioDomicilio>? UsuarioDomicilio { get; set; }
    }
}

