using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IConsultasPresentacion
    {
        Consultas Insertar(Consultas entidad);
        Consultas Actualizar(Consultas entidad);
        List<Consultas> Consultar();
        List<Consultas> Buscar(Consultas entidad);
        Consultas Borrar(Consultas entidad);
    }
}