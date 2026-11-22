using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ICitasPresentacion
    {
        Citas Insertar(Citas entidad);
        Citas Actualizar(Citas entidad);
        List<Citas> Consultar();
        List<Citas> Buscar(Citas entidad);
        Citas Borrar(Citas entidad);
    }
}