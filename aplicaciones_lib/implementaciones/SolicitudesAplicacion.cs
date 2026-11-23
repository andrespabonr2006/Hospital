using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class SolicitudesAplicacion : ISolicitudesAplicacion
    {
        private IConexion conexion;

        public SolicitudesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Solicitudes Actualizar(Solicitudes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Solicitudes>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            Auditoria.Registrar(this.conexion, "Solicitudes", "Actualizar", entidad.Id);
            return entidad;
        }

        public Solicitudes Borrar(Solicitudes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Solicitudes!.Remove(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Solicitudes", "Borrar", entidad.Id);
            return entidad;
        }

        public List<Solicitudes> Buscar(Solicitudes entidad)
        {
            return this.conexion.Solicitudes!
                .Where(x => x.Motivo!.Contains(entidad.Motivo!))
                .Include(x => x._Paciente)
                .ToList();
        }

        public List<Solicitudes> Consultar()
        {
            return this.conexion.Solicitudes!
                .Include(x => x._Paciente)
                .Take(5).ToList();
        }

        public Solicitudes Insertar(Solicitudes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Solicitudes!.Add(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Solicitudes", "Insertar", entidad.Id);
            return entidad;
        }

        private bool Validar(Solicitudes entidad)
        {
            return entidad.Fecha == null ||
                string.IsNullOrEmpty(entidad.NivelUrgencia) ||
                string.IsNullOrEmpty(entidad.Motivo) ||
                entidad.Paciente <= 0;
        }

        private void ValidarRelaciones(Solicitudes entidad)
        {
            if (!this.conexion.Pacientes!.Any(x => x.Id == entidad.Paciente))
                throw new Exception("No existe Paciente con Id " + entidad.Paciente);
        }
    }
}
