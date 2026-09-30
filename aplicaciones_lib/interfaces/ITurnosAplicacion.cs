using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ITurnosAplicacion
    {
        Turnos Insertar(Turnos entidad);
        List<Turnos> Consultar();
        Turnos Actualizar(Turnos entidad);
        Turnos Borrar(Turnos entidad);
    }
}
