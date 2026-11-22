using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ConsultoriosController : ControllerBase
    {
        private IConsultoriosAplicacion IConsultoriosAplicacion;

        public ConsultoriosController(IConsultoriosAplicacion IConsultoriosAplicacion)
        {
            this.IConsultoriosAplicacion = IConsultoriosAplicacion;
        }

        [HttpPost]
        public List<Consultorios> Consultar()
        {
            return this.IConsultoriosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Consultorios> Buscar(Consultorios entidad)
        {
            return this.IConsultoriosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Consultorios Insertar(Consultorios entidad)
        {
            return this.IConsultoriosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Consultorios Actualizar(Consultorios entidad)
        {
            return this.IConsultoriosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Consultorios Borrar(Consultorios entidad)
        {
            return this.IConsultoriosAplicacion.Borrar(entidad);
        }
    }
}
