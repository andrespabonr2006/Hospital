using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class PacientesAplicacion : IPacientesAplicacion
    {
        private IConexion conexion;

        public PacientesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Pacientes Actualizar(Pacientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Pacientes>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            Auditoria.Registrar(this.conexion, "Pacientes", "Actualizar", entidad.Id);
            return entidad;
        }

        public Pacientes Borrar(Pacientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Pacientes!.Remove(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Pacientes", "Borrar", entidad.Id);
            return entidad;
        }

        public List<Pacientes> Buscar(Pacientes entidad)
        {
            return this.conexion.Pacientes!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Pacientes> Consultar()
        {
            return this.conexion.Pacientes!.Take(5).ToList();
        }

        public Pacientes Insertar(Pacientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Pacientes!.Add(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Pacientes", "Insertar", entidad.Id);
            return entidad;
        }

        private bool Validar(Pacientes entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.FechaNacimiento == null ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                string.IsNullOrEmpty(entidad.Direccion);
        }
    }
}
