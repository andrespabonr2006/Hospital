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
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Turnos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Turnos Borrar(Turnos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Turnos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Turnos> Buscar(Turnos entidad)
        {
            return this.conexion.Turnos!
                .Where(x => x.Jornada!.Contains(entidad.Jornada!))
                .Include(x => x._Medico)
                .ToList();
        }

        public List<Turnos> Consultar()
        {
            return this.conexion.Turnos!
                .Include(x => x._Medico)
                .Take(5).ToList();
        }

        public Turnos Insertar(Turnos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Turnos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Turnos entidad)
        {
            return string.IsNullOrEmpty(entidad.Jornada) ||
                entidad.HoraInicio == null ||
                entidad.HoraFinal == null ||
                entidad.Medico <= 0;
        }

        private void ValidarRelaciones(Turnos entidad)
        {
            if (!this.conexion.Medicos!.Any(x => x.Id == entidad.Medico))
                throw new Exception("No existe Medico con Id " + entidad.Medico);
        }
    }
}
