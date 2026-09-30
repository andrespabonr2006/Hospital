using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ISegurosAplicacion
    {
        Seguros Insertar(Seguros entidad);
        List<Seguros> Consultar();
        Seguros Actualizar(Seguros entidad);
        Seguros Borrar(Seguros entidad);
    }
}
