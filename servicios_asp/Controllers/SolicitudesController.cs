using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SolicitudesController : ControllerBase
    {
        private ISolicitudesAplicacion ISolicitudesAplicacion;

        public SolicitudesController(ISolicitudesAplicacion ISolicitudesAplicacion)
        {
            this.ISolicitudesAplicacion = ISolicitudesAplicacion;
        }

        [HttpPost]
        public List<Solicitudes> Consultar()
        {
            return this.ISolicitudesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Solicitudes> Buscar(Solicitudes entidad)
        {
            return this.ISolicitudesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Solicitudes Insertar(Solicitudes entidad)
        {
            return this.ISolicitudesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Solicitudes Actualizar(Solicitudes entidad)
        {
            return this.ISolicitudesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Solicitudes Borrar(Solicitudes entidad)
        {
            return this.ISolicitudesAplicacion.Borrar(entidad);
        }
    }
}

