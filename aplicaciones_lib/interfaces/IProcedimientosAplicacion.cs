using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IProcedimientosAplicacion
    {
        Procedimientos Insertar(Procedimientos entidad);
        Procedimientos Actualizar(Procedimientos entidad);
        List<Procedimientos> Consultar();
        List<Procedimientos> Buscar(Procedimientos entidad);
        Procedimientos Borrar(Procedimientos entidad);
    }
}
