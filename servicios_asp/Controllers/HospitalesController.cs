using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HospitalesController : ControllerBase
    {
        private IHospitalesAplicacion IHospitalesAplicacion;

        public HospitalesController(IHospitalesAplicacion IHospitalesAplicacion)
        {
            this.IHospitalesAplicacion = IHospitalesAplicacion;
        }

        [HttpPost]
        public List<Hospitales> Consultar()
        {
            return this.IHospitalesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Hospitales> Buscar(Hospitales entidad)
        {
            return this.IHospitalesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Hospitales Insertar(Hospitales entidad)
        {
            return this.IHospitalesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Hospitales Actualizar(Hospitales entidad)
        {
            return this.IHospitalesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Hospitales Borrar(Hospitales entidad)
        {
            return this.IHospitalesAplicacion.Borrar(entidad);
        }
    }
}
