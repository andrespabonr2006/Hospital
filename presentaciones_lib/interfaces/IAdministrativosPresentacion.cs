using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IAdministrativosPresentacion
    {
        Administrativos Insertar(Administrativos entidad);
        Administrativos Actualizar(Administrativos entidad);
        List<Administrativos> Consultar();
        List<Administrativos> Buscar(Administrativos entidad);
        Administrativos Borrar(Administrativos entidad);
    }
}