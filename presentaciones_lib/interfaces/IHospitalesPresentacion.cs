using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IHospitalesPresentacion
    {
        Hospitales Insertar(Hospitales entidad);
        Hospitales Actualizar(Hospitales entidad);
        List<Hospitales> Consultar();
        List<Hospitales> Buscar(Hospitales entidad);
        Hospitales Borrar(Hospitales entidad);
    }
}