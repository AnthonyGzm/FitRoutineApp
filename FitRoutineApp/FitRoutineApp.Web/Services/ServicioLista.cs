using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitRoutineApp.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitRoutineApp.Web.Services
{
    public class ServicioLista : IServicioLista
    {
        private readonly FitRoutineContext _context;

        public ServicioLista(FitRoutineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaClientes()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            if (_context != null && _context.Clientes != null)
            {
                list = await _context.Clientes
                    .Select(x => new SelectListItem
                    {
                        Text = x.Nombre,
                        Value = x.Id.ToString()
                    })
                    .OrderBy(x => x.Text)
                    .ToListAsync();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Cliente...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaActividades()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            if (_context != null && _context.Actividades != null)
            {
                list = await _context.Actividades
                    .Select(x => new SelectListItem
                    {
                        Text = x.Nombre,
                        Value = x.Id.ToString()
                    })
                    .OrderBy(x => x.Text)
                    .ToListAsync();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Actividad...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaEntrenadores()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            if (_context != null && _context.Entrenadores != null)
            {
                list = await _context.Entrenadores
                    .Select(x => new SelectListItem
                    {
                        Text = x.Nombre,
                        Value = x.Id.ToString()
                    })
                    .OrderBy(x => x.Text)
                    .ToListAsync();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Entrenador...]",
                Value = "0"
            });

            return list;
        }
    }
}
