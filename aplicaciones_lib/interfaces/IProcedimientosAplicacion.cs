using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IProcedimientosAplicacion
    {
        Procedimientos Insertar(Procedimientos entidad);
        List<Procedimientos> Consultar();
        Procedimientos Actualizar(Procedimientos entidad);
        Procedimientos Borrar(Procedimientos entidad);
    }
}
