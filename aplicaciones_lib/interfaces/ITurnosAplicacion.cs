using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ITurnosAplicacion
    {
        Turnos Insertar(Turnos entidad);
        Turnos Actualizar(Turnos entidad);
        List<Turnos> Consultar();
        List<Turnos> Buscar(Turnos entidad);
        Turnos Borrar(Turnos entidad);
    }
}
