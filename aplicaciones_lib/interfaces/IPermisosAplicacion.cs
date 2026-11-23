using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IPermisosAplicacion
    {
        Permisos Insertar(Permisos entidad);
        Permisos Actualizar(Permisos entidad);
        List<Permisos> Consultar();
        List<Permisos> Buscar(Permisos entidad);
        Permisos Borrar(Permisos entidad);
    }
}
