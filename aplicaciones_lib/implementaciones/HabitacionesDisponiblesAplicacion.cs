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
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Habitaciones>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Habitaciones Borrar(Habitaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Habitaciones!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Habitaciones> Buscar(Habitaciones entidad)
        {
            return this.conexion.Habitaciones!
                .Where(x => x.Tipo!.Contains(entidad.Tipo!))
                .Include(x => x._Sector).Include(x => x._Paciente)
                .ToList();
        }

        public List<Habitaciones> Consultar()
        {
            return this.conexion.Habitaciones!
                .Where(x => x.Disponibilidad)
                .Include(x => x._Sector).Include(x => x._Paciente)
                .ToList();
        }

        public Habitaciones Insertar(Habitaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Habitaciones!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Habitaciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Tipo) ||
                entidad.Sector <= 0 ||
                entidad.Paciente <= 0;
        }

        private void ValidarRelaciones(Habitaciones entidad)
        {
            if (!this.conexion.Sectores!.Any(x => x.Id == entidad.Sector))
                throw new Exception("No existe Sector con Id " + entidad.Sector);

            if (!this.conexion.Pacientes!.Any(x => x.Id == entidad.Paciente))
                throw new Exception("No existe Paciente con Id " + entidad.Paciente);
        }
    }
}
