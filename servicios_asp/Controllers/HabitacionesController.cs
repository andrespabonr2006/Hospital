using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HabitacionesController : ControllerBase
    {
        private IHabitacionesAplicacion IHabitacionesAplicacion;

        public HabitacionesController(IHabitacionesAplicacion IHabitacionesAplicacion)
        {
            this.IHabitacionesAplicacion = IHabitacionesAplicacion;
        }

        [HttpPost]
        public List<Habitaciones> Consultar()
        {
            return this.IHabitacionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Habitaciones> Buscar(Habitaciones entidad)
        {
            return this.IHabitacionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Habitaciones Insertar(Habitaciones entidad)
        {
            return this.IHabitacionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Habitaciones Actualizar(Habitaciones entidad)
        {
            return this.IHabitacionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Habitaciones Borrar(Habitaciones entidad)
        {
            return this.IHabitacionesAplicacion.Borrar(entidad);
        }
    }
}
