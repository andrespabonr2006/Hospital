using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class ConsultasAplicacion : IConsultasAplicacion
    {
        private IConexion conexion;

        public ConsultasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Consultas Actualizar(Consultas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Consultas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Consultas Borrar(Consultas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Consultas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Consultas> Buscar(Consultas entidad)
        {
            return this.conexion.Consultas!
                .Where(x => x.Observacion!.Contains(entidad.Observacion!))
                .Include(x => x._Cita)
                .ToList();
        }

        public List<Consultas> Consultar()
        {
            return this.conexion.Consultas!
                .Include(x => x._Cita)
                .Take(5).ToList();
        }

        public Consultas Insertar(Consultas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Consultas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Consultas entidad)
        {
            return string.IsNullOrEmpty(entidad.Observacion) ||
                string.IsNullOrEmpty(entidad.SignosVitales) ||
                entidad.Cita <= 0;
        }

        private void ValidarRelaciones(Consultas entidad)
        {
            if (!this.conexion.Citas!.Any(x => x.Id == entidad.Cita))
                throw new Exception("No existe Cita con Id " + entidad.Cita);
        }
    }
}
