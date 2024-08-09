namespace FitRoutineApp.Web.Models
{
    public class Pago
    {
        public int Id { get; set; }

        public Sesion? Sesion { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public string MetodoPago { get; set; } = null!;
    }
}