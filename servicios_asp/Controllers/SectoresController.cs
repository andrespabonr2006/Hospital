using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SectoresController : ControllerBase
    {
        private ISectoresAplicacion ISectoresAplicacion;

        public SectoresController(ISectoresAplicacion ISectoresAplicacion)
        {
            this.ISectoresAplicacion = ISectoresAplicacion;
        }

        [HttpPost]
        public List<Sectores> Consultar()
        {
            return this.ISectoresAplicacion.Consultar();
        }

        [HttpPost]
        public List<Sectores> Buscar(Sectores entidad)
        {
            return this.ISectoresAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Sectores Insertar(Sectores entidad)
        {
            return this.ISectoresAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Sectores Actualizar(Sectores entidad)
        {
            return this.ISectoresAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Sectores Borrar(Sectores entidad)
        {
            return this.ISectoresAplicacion.Borrar(entidad);
        }
    }
}
