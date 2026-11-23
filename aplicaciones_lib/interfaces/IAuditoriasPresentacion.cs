using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IAuditoriasPresentacion
    {
        Auditorias Insertar(Auditorias entidad);
        List<Auditorias> Consultar();
        List<Auditorias> Buscar(Auditorias entidad);
    }
}
