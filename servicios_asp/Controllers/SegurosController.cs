using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SegurosController : ControllerBase
    {
        private ISegurosAplicacion ISegurosAplicacion;

        public SegurosController(ISegurosAplicacion ISegurosAplicacion)
        {
            this.ISegurosAplicacion = ISegurosAplicacion;
        }

        [HttpPost]
        public List<Seguros> Consultar()
        {
            return this.ISegurosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Seguros> Buscar(Seguros entidad)
        {
            return this.ISegurosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Seguros Insertar(Seguros entidad)
        {
            return this.ISegurosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Seguros Actualizar(Seguros entidad)
        {
            return this.ISegurosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Seguros Borrar(Seguros entidad)
        {
            return this.ISegurosAplicacion.Borrar(entidad);
        }
    }
}
