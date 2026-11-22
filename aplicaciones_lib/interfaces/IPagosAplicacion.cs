using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IPagosAplicacion
    {
        Pagos Insertar(Pagos entidad);
        Pagos Actualizar(Pagos entidad);
        List<Pagos> Consultar();
        List<Pagos> Buscar(Pagos entidad);
        Pagos Borrar(Pagos entidad);
    }
}

