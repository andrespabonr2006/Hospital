using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdministrativosController : ControllerBase
    {
        private IAdministrativosAplicacion IAdministrativosAplicacion;

        public AdministrativosController(IAdministrativosAplicacion IAdministrativosAplicacion)
        {
            this.IAdministrativosAplicacion = IAdministrativosAplicacion;
        }

        [HttpPost]
        public List<Administrativos> Consultar()
        {
            return this.IAdministrativosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Administrativos> Buscar(Administrativos entidad)
        {
            return this.IAdministrativosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Administrativos Insertar(Administrativos entidad)
        {
            return this.IAdministrativosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Administrativos Actualizar(Administrativos entidad)
        {
            return this.IAdministrativosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Administrativos Borrar(Administrativos entidad)
        {
            return this.IAdministrativosAplicacion.Borrar(entidad);
        }
    }
}
