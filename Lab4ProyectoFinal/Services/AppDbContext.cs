using Lab4ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4ProyectoFinal.Services
{
	public class AppDbContext: DbContext
	{
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioDomicilio>().HasKey(x => new { x.UsuarioId, x.DomicilioId });
            modelBuilder.Entity<UsuarioTarjeta>().HasKey(x => new { x.UsuarioId, x.TarjetaId });
        }

        public DbSet<Producto> Productos { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Proveedor> Proveedores { get; set; }
		public DbSet<MetodoDePago> MetodoDePagos { get; set; }
	    public DbSet<Domicilio> Domicilio { get; set; }
        public DbSet<UsuarioDomicilio> UsuarioDomicilios { get; set; }
        public DbSet<UsuarioTarjeta> UsuarioTarjeta { get; set; }
    }
}
