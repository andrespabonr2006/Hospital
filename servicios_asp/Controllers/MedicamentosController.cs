using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MedicamentosController : ControllerBase
    {
        private IMedicamentosAplicacion IMedicamentosAplicacion;

        public MedicamentosController(IMedicamentosAplicacion IMedicamentosAplicacion)
        {
            this.IMedicamentosAplicacion = IMedicamentosAplicacion;
        }

        [HttpPost]
        public List<Medicamentos> Consultar()
        {
            return this.IMedicamentosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Medicamentos> Buscar(Medicamentos entidad)
        {
            return this.IMedicamentosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Medicamentos Insertar(Medicamentos entidad)
        {
            return this.IMedicamentosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Medicamentos Actualizar(Medicamentos entidad)
        {
            return this.IMedicamentosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Medicamentos Borrar(Medicamentos entidad)
        {
            return this.IMedicamentosAplicacion.Borrar(entidad);
        }
    }
}
