using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ISectoresAplicacion
    {
        Sectores Insertar(Sectores entidad);
        Sectores Actualizar(Sectores entidad);
        List<Sectores> Consultar();
        List<Sectores> Buscar(Sectores entidad);
        Sectores Borrar(Sectores entidad);
    }
}
