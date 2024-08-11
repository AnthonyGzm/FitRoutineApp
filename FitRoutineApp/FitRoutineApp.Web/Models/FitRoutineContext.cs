using Microsoft.EntityFrameworkCore;

namespace FitRoutineApp.Web.Models
{
    public class FitRoutineContext : DbContext
    {
        public FitRoutineContext(DbContextOptions<FitRoutineContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para Cliente
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            // Configuración para Entrenador
            modelBuilder.Entity<Entrenador>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Entrenador>()
                .HasOne(e => e.Especialidad)
                .WithMany()
                .HasForeignKey(e => e.EspecialidadId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Configuración para Sesion
            modelBuilder.Entity<Sesion>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Sesion>()
                .HasOne(s => s.Cliente)
                .WithMany()
                .HasForeignKey(s => s.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sesion>()
                .HasOne(s => s.Entrenador)
                .WithMany()
                .HasForeignKey(s => s.EntrenadorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sesion>()
                .HasOne(s => s.Actividad)
                .WithMany()
                .HasForeignKey(s => s.ActividadId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para Actividad
            modelBuilder.Entity<Actividad>()
                .HasKey(a => a.Id);

            // Configuración para Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);
        }
    }
}