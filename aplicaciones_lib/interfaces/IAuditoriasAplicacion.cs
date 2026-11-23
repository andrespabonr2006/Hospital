using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    // La auditoria no se edita ni se borra: solo se consulta y se inserta.
    public interface IAuditoriasAplicacion
    {
        Auditorias Insertar(Auditorias entidad);
        List<Auditorias> Consultar();
        List<Auditorias> Buscar(Auditorias entidad);
    }
}
