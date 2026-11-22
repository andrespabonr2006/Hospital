using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FormulasController : ControllerBase
    {
        private IFormulasAplicacion IFormulasAplicacion;

        public FormulasController(IFormulasAplicacion IFormulasAplicacion)
        {
            this.IFormulasAplicacion = IFormulasAplicacion;
        }

        [HttpPost]
        public List<Formulas> Consultar()
        {
            return this.IFormulasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Formulas> Buscar(Formulas entidad)
        {
            return this.IFormulasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Formulas Insertar(Formulas entidad)
        {
            return this.IFormulasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Formulas Actualizar(Formulas entidad)
        {
            return this.IFormulasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Formulas Borrar(Formulas entidad)
        {
            return this.IFormulasAplicacion.Borrar(entidad);
        }
    }
}
