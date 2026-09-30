using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IPagosAplicacion
    {
        Pagos Insertar(Pagos entidad);
        List<Pagos> Consultar();
        Pagos Actualizar(Pagos entidad);
        Pagos Borrar(Pagos entidad);
    }
}
