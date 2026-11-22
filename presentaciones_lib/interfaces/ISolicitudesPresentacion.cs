using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ISolicitudesPresentacion
    {
        Solicitudes Insertar(Solicitudes entidad);
        Solicitudes Actualizar(Solicitudes entidad);
        List<Solicitudes> Consultar();
        List<Solicitudes> Buscar(Solicitudes entidad);
        Solicitudes Borrar(Solicitudes entidad);
    }
}