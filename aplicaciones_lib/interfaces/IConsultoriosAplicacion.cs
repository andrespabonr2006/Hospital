using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IConsultoriosAplicacion
    {
        Consultorios Insertar(Consultorios entidad);
        List<Consultorios> Consultar();
        Consultorios Actualizar(Consultorios entidad);
        Consultorios Borrar(Consultorios entidad);
    }
}
