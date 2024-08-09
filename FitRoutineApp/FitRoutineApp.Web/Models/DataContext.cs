using Microsoft.EntityFrameworkCore;

namespace FitRoutineApp.Web.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Sesion> Sesiones { get; set; }

        public DbSet<Entrenador> Entrenadores { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<HistorialDeActividades> HistorialDeActividades { get; set; }
    }
}