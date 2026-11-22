using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IAdministrativosAplicacion
    {
        Administrativos Insertar(Administrativos entidad);
        Administrativos Actualizar(Administrativos entidad);
        List<Administrativos> Consultar();
        List<Administrativos> Buscar(Administrativos entidad);
        Administrativos Borrar(Administrativos entidad);
    }
}

