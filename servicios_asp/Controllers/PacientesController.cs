using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PacientesController : ControllerBase
    {
        private IPacientesAplicacion IPacientesAplicacion;

        public PacientesController(IPacientesAplicacion IPacientesAplicacion)
        {
            this.IPacientesAplicacion = IPacientesAplicacion;
        }

        [HttpPost]
        public List<Pacientes> Consultar()
        {
            return this.IPacientesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Pacientes> Buscar(Pacientes entidad)
        {
            return this.IPacientesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Pacientes Insertar(Pacientes entidad)
        {
            return this.IPacientesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Pacientes Actualizar(Pacientes entidad)
        {
            return this.IPacientesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Pacientes Borrar(Pacientes entidad)
        {
            return this.IPacientesAplicacion.Borrar(entidad);
        }
    }
}
