using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IConsultasAplicacion
    {
        Consultas Insertar(Consultas entidad);
        List<Consultas> Consultar();
        Consultas Actualizar(Consultas entidad);
        Consultas Borrar(Consultas entidad);
    }
}
