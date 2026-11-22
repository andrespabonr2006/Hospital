using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class ProcedimientosAplicacion : IProcedimientosAplicacion
    {
        private IConexion conexion;

        public ProcedimientosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Procedimientos Actualizar(Procedimientos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Procedimientos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Procedimientos Borrar(Procedimientos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Procedimientos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Procedimientos> Buscar(Procedimientos entidad)
        {
            return this.conexion.Procedimientos!
                .Where(x => x.Proceso!.Contains(entidad.Proceso!))
                .Include(x => x._Examen)
                .ToList();
        }

        public List<Procedimientos> Consultar()
        {
            return this.conexion.Procedimientos!
                .Include(x => x._Examen)
                .Take(5).ToList();
        }

        public Procedimientos Insertar(Procedimientos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Procedimientos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Procedimientos entidad)
        {
            return string.IsNullOrEmpty(entidad.Proceso) ||
                string.IsNullOrEmpty(entidad.Duracion) ||
                entidad.Examen <= 0;
        }

        private void ValidarRelaciones(Procedimientos entidad)
        {
            if (!this.conexion.Examenes!.Any(x => x.Id == entidad.Examen))
                throw new Exception("No existe Examen con Id " + entidad.Examen);
        }
    }
}
