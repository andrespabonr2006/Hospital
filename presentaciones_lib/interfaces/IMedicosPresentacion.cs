using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IMedicosPresentacion
    {
        Medicos Insertar(Medicos entidad);
        Medicos Actualizar(Medicos entidad);
        List<Medicos> Consultar();
        List<Medicos> Buscar(Medicos entidad);
        Medicos Borrar(Medicos entidad);
    }
}