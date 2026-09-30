using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class HabitacionesDisponiblesAplicacion : IHabitacionesAplicacion
    {
        private IConexion conexion;

        public HabitacionesDisponiblesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Habitaciones Actualizar(Habitaciones entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Habitaciones>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Habitaciones Borrar(Habitaciones entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Habitaciones!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Habitaciones> Consultar()
        {
            return this.conexion.Habitaciones!
                .Where(x => x.Disponibilidad)
                .ToList();
        }

        public Habitaciones Insertar(Habitaciones entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Habitaciones!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
