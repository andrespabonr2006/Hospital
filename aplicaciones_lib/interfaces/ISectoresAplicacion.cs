using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ISectoresAplicacion
    {
        Sectores Insertar(Sectores entidad);
        List<Sectores> Consultar();
        Sectores Actualizar(Sectores entidad);
        Sectores Borrar(Sectores entidad);
    }
}