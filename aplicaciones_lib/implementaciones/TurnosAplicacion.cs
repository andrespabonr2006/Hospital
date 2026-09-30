using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class TurnosAplicacion : ITurnosAplicacion
    {
        private IConexion conexion;

        public TurnosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Turnos Actualizar(Turnos entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Turnos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Turnos Borrar(Turnos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Turnos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Turnos> Consultar()
        {
            return this.conexion.Turnos!.ToList();
        }

        public Turnos Insertar(Turnos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Turnos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
