using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanzasWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<TipoMovimiento> TipoMovimientos => Set<TipoMovimiento>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Movimiento> Movimientos => Set<Movimiento>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Usuario
            modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasMaxLength(100);
            modelBuilder.Entity<Usuario>().Property(u => u.Apellido).HasMaxLength(100);
            modelBuilder.Entity<Usuario>().Property(u => u.Email).HasMaxLength(50);
            modelBuilder.Entity<Usuario>().Property(u => u.Clave).HasMaxLength(50);
            modelBuilder.Entity<Usuario>().Property(u => u.FechaRegistro).HasColumnType("date");
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();

            //TipoMovimiento
            modelBuilder.Entity<TipoMovimiento>().Property(t => t.Nombre).HasMaxLength(50);

            //Categoria
            modelBuilder.Entity<Categoria>().Property(u => u.Nombre).HasMaxLength(100);

            //Movimiento
            modelBuilder.Entity<Movimiento>().Property(u => u.Fecha).HasColumnType("date");
            modelBuilder.Entity<Movimiento>().Property(u => u.Descripcion).HasMaxLength(200);
            modelBuilder.Entity<Movimiento>().Property(u => u.Monto).HasPrecision(18,2);

        }
    }
}
