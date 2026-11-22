using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExamenesController : ControllerBase
    {
        private IExamenesAplicacion IExamenesAplicacion;

        public ExamenesController(IExamenesAplicacion IExamenesAplicacion)
        {
            this.IExamenesAplicacion = IExamenesAplicacion;
        }

        [HttpPost]
        public List<Examenes> Consultar()
        {
            return this.IExamenesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Examenes> Buscar(Examenes entidad)
        {
            return this.IExamenesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Examenes Insertar(Examenes entidad)
        {
            return this.IExamenesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Examenes Actualizar(Examenes entidad)
        {
            return this.IExamenesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Examenes Borrar(Examenes entidad)
        {
            return this.IExamenesAplicacion.Borrar(entidad);
        }
    }
}
