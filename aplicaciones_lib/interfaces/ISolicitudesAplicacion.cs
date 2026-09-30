using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ISolicitudesAplicacion
    {
        Solicitudes Insertar(Solicitudes entidad);
        List<Solicitudes> Consultar();
        Solicitudes Actualizar(Solicitudes entidad);
        Solicitudes Borrar(Solicitudes entidad);
    }
}