using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class CitasAplicacion : ICitasAplicacion
    {
        private IConexion conexion;

        public CitasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Citas Actualizar(Citas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Citas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            Auditoria.Registrar(this.conexion, "Citas", "Actualizar", entidad.Id);
            return entidad;
        }

        public Citas Borrar(Citas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Citas!.Remove(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Citas", "Borrar", entidad.Id);
            return entidad;
        }

        public List<Citas> Buscar(Citas entidad)
        {
            return this.conexion.Citas!
                .Where(x => x.Estado!.Contains(entidad.Estado!))
                .Include(x => x._Solicitud).Include(x => x._Paciente)
                .ToList();
        }

        public List<Citas> Consultar()
        {
            return this.conexion.Citas!
                .Include(x => x._Solicitud).Include(x => x._Paciente)
                .Take(5).ToList();
        }

        public Citas Insertar(Citas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Citas!.Add(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Citas", "Insertar", entidad.Id);
            return entidad;
        }

        private bool Validar(Citas entidad)
        {
            return entidad.Fecha == null ||
                string.IsNullOrEmpty(entidad.Estado) ||
                entidad.Solicitud <= 0 ||
                entidad.Paciente <= 0;
        }

        private void ValidarRelaciones(Citas entidad)
        {
            if (!this.conexion.Solicitudes!.Any(x => x.Id == entidad.Solicitud))
                throw new Exception("No existe Solicitud con Id " + entidad.Solicitud);

            if (!this.conexion.Pacientes!.Any(x => x.Id == entidad.Paciente))
                throw new Exception("No existe Paciente con Id " + entidad.Paciente);
        }
    }
}
