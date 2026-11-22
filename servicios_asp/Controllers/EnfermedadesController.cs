using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EnfermedadesController : ControllerBase
    {
        private IEnfermedadesAplicacion IEnfermedadesAplicacion;

        public EnfermedadesController(IEnfermedadesAplicacion IEnfermedadesAplicacion)
        {
            this.IEnfermedadesAplicacion = IEnfermedadesAplicacion;
        }

        [HttpPost]
        public List<Enfermedades> Consultar()
        {
            return this.IEnfermedadesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Enfermedades> Buscar(Enfermedades entidad)
        {
            return this.IEnfermedadesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Enfermedades Insertar(Enfermedades entidad)
        {
            return this.IEnfermedadesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Enfermedades Actualizar(Enfermedades entidad)
        {
            return this.IEnfermedadesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Enfermedades Borrar(Enfermedades entidad)
        {
            return this.IEnfermedadesAplicacion.Borrar(entidad);
        }
    }
}
