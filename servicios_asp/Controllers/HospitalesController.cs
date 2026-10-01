using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.AspNetCore.Mvc;

namespace servicios_asp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalesController : ControllerBase
    {
        private IHospitalesAplicacion iAplicacion;

        public HospitalesController()
        {
            IConexion conexion = new Conexion();
            conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            this.iAplicacion = new HospitalesAplicacion(conexion);
        }

        [HttpGet]
        public List<Hospitales> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}