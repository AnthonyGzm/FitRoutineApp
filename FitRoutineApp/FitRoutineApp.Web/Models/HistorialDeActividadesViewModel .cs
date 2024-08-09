namespace FitRoutineApp.Web.Models
{
    public class HistorialDeActividadesViewModel : HistorialDeActividades
    {
        public int IdUsuario { get; set; }
        public IEnumerable<HistorialDeActividades> HistorialesDeActividades { get; set; } = new List<HistorialDeActividades>();
    }
}