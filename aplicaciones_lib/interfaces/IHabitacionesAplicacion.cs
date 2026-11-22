using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IHabitacionesAplicacion
    {
        Habitaciones Insertar(Habitaciones entidad);
        Habitaciones Actualizar(Habitaciones entidad);
        List<Habitaciones> Consultar();
        List<Habitaciones> Buscar(Habitaciones entidad);
        Habitaciones Borrar(Habitaciones entidad);
    }
}

