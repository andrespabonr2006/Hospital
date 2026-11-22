using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProcedimientosController : ControllerBase
    {
        private IProcedimientosAplicacion IProcedimientosAplicacion;

        public ProcedimientosController(IProcedimientosAplicacion IProcedimientosAplicacion)
        {
            this.IProcedimientosAplicacion = IProcedimientosAplicacion;
        }

        [HttpPost]
        public List<Procedimientos> Consultar()
        {
            return this.IProcedimientosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Procedimientos> Buscar(Procedimientos entidad)
        {
            return this.IProcedimientosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Procedimientos Insertar(Procedimientos entidad)
        {
            return this.IProcedimientosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Procedimientos Actualizar(Procedimientos entidad)
        {
            return this.IProcedimientosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Procedimientos Borrar(Procedimientos entidad)
        {
            return this.IProcedimientosAplicacion.Borrar(entidad);
        }
    }
}
