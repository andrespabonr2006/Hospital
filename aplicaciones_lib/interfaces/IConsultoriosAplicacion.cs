using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IConsultoriosAplicacion
    {
        Consultorios Insertar(Consultorios entidad);
        Consultorios Actualizar(Consultorios entidad);
        List<Consultorios> Consultar();
        List<Consultorios> Buscar(Consultorios entidad);
        Consultorios Borrar(Consultorios entidad);
    }
}

