using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IHistorialesAplicacion
    {
        Historiales Insertar(Historiales entidad);
        List<Historiales> Consultar();
        Historiales Actualizar(Historiales entidad);
        Historiales Borrar(Historiales entidad);
    }
}
