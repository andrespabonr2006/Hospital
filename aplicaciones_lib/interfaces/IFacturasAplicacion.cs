using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IFacturasAplicacion
    {
        Facturas Insertar(Facturas entidad);
        List<Facturas> Consultar();
        Facturas Actualizar(Facturas entidad);
        Facturas Borrar(Facturas entidad);
    }
}
