using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MedicosController : ControllerBase
    {
        private IMedicosAplicacion IMedicosAplicacion;

        public MedicosController(IMedicosAplicacion IMedicosAplicacion)
        {
            this.IMedicosAplicacion = IMedicosAplicacion;
        }

        [HttpPost]
        public List<Medicos> Consultar()
        {
            return this.IMedicosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Medicos> Buscar(Medicos entidad)
        {
            return this.IMedicosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Medicos Insertar(Medicos entidad)
        {
            return this.IMedicosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Medicos Actualizar(Medicos entidad)
        {
            return this.IMedicosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Medicos Borrar(Medicos entidad)
        {
            return this.IMedicosAplicacion.Borrar(entidad);
        }
    }
}
