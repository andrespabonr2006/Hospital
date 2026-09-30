using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IMedicosAplicacion
    {
        Medicos Insertar(Medicos entidad);
        List<Medicos> Consultar();
        Medicos Actualizar(Medicos entidad);
        Medicos Borrar(Medicos entidad);
    }
}
