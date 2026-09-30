using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IHabitacionesAplicacion
    {
        Habitaciones Insertar(Habitaciones entidad);
        List<Habitaciones> Consultar();
        Habitaciones Actualizar(Habitaciones entidad);
        Habitaciones Borrar(Habitaciones entidad);
    }
}
