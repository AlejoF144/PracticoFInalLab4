namespace Lab4ProyectoFinal.Models
{
    
        public class Usuario
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
            public int Nivel { get; set; }
            public bool Estado { get; set; }
            public string? ImagenCarpeta { get; set; }

            // Propiedades para referenciar MetodoDePago y Domicilio
            public int? MetodoDePagoId { get; set; }
            public MetodoDePago? MetodoDePago { get; set; }

            public int? DomicilioId { get; set; }
            public Domicilio? Domicilio { get; set; }
        }

    }



