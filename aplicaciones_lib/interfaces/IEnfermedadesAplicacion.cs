using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IEnfermedadesAplicacion
    {
        Enfermedades Insertar(Enfermedades entidad);
        List<Enfermedades> Consultar();
        Enfermedades Actualizar(Enfermedades entidad);
        Enfermedades Borrar(Enfermedades entidad);
    }
}