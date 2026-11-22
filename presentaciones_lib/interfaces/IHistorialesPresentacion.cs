using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IHistorialesPresentacion
    {
        Historiales Insertar(Historiales entidad);
        Historiales Actualizar(Historiales entidad);
        List<Historiales> Consultar();
        List<Historiales> Buscar(Historiales entidad);
        Historiales Borrar(Historiales entidad);
    }
}