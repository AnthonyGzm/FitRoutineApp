using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitRoutineApp.Web.Services
{
    public interface IServicioLista
    {
        Task<IEnumerable<SelectListItem>> GetListaClientes();
        Task<IEnumerable<SelectListItem>> GetListaActividades();
        Task<IEnumerable<SelectListItem>> GetListaEntrenadores();
    }
}
