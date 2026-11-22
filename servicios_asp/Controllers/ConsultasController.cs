using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ConsultasController : ControllerBase
    {
        private IConsultasAplicacion IConsultasAplicacion;

        public ConsultasController(IConsultasAplicacion IConsultasAplicacion)
        {
            this.IConsultasAplicacion = IConsultasAplicacion;
        }

        [HttpPost]
        public List<Consultas> Consultar()
        {
            return this.IConsultasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Consultas> Buscar(Consultas entidad)
        {
            return this.IConsultasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Consultas Insertar(Consultas entidad)
        {
            return this.IConsultasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Consultas Actualizar(Consultas entidad)
        {
            return this.IConsultasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Consultas Borrar(Consultas entidad)
        {
            return this.IConsultasAplicacion.Borrar(entidad);
        }
    }
}
