using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IAdministrativosAplicacion
    {
        Administrativos Insertar(Administrativos entidad);
        List<Administrativos> Consultar();
        Administrativos Actualizar(Administrativos entidad);
        Administrativos Borrar(Administrativos entidad);
    }
}
