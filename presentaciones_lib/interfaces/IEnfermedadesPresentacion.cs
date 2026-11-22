using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IEnfermedadesPresentacion
    {
        Enfermedades Insertar(Enfermedades entidad);
        Enfermedades Actualizar(Enfermedades entidad);
        List<Enfermedades> Consultar();
        List<Enfermedades> Buscar(Enfermedades entidad);
        Enfermedades Borrar(Enfermedades entidad);
    }
}