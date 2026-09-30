using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ICitasAplicacion
    {
        Citas Insertar(Citas entidad);
        List<Citas> Consultar();
        Citas Actualizar(Citas entidad);
        Citas Borrar(Citas entidad);
    }
}
