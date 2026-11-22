using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HistorialesController : ControllerBase
    {
        private IHistorialesAplicacion IHistorialesAplicacion;

        public HistorialesController(IHistorialesAplicacion IHistorialesAplicacion)
        {
            this.IHistorialesAplicacion = IHistorialesAplicacion;
        }

        [HttpPost]
        public List<Historiales> Consultar()
        {
            return this.IHistorialesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Historiales> Buscar(Historiales entidad)
        {
            return this.IHistorialesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Historiales Insertar(Historiales entidad)
        {
            return this.IHistorialesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Historiales Actualizar(Historiales entidad)
        {
            return this.IHistorialesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Historiales Borrar(Historiales entidad)
        {
            return this.IHistorialesAplicacion.Borrar(entidad);
        }
    }
}
