using Lab4ProyectoFinal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab4ProyectoFinal.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioDomicilio>().HasKey(x => new { x.UsuarioId, x.DomicilioId });
            modelBuilder.Entity<UsuarioTarjeta>().HasKey(x => new { x.UsuarioId, x.TarjetaId });
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
       
        public DbSet<MetodoDePago> MetodoDePagos { get; set; }
        public DbSet<Domicilio> Domicilio { get; set; }
        public DbSet<UsuarioDomicilio> UsuarioDomicilios { get; set; }
        public DbSet<UsuarioTarjeta> UsuarioTarjeta { get; set; }
    }
}
