using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IHospitalesAplicacion
    {
        Hospitales Insertar(Hospitales entidad);
        List<Hospitales> Consultar();
        Hospitales Actualizar(Hospitales entidad);
        Hospitales Borrar(Hospitales entidad);
    }
}
