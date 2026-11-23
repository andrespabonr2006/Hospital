using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class PermisosAplicacion : IPermisosAplicacion
    {
        private IConexion conexion;

        public PermisosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Permisos Actualizar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            Auditoria.Registrar(this.conexion, "Permisos", "Actualizar", entidad.Id);
            return entidad;
        }

        public Permisos Borrar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Permisos!.Remove(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Permisos", "Borrar", entidad.Id);
            return entidad;
        }

        public List<Permisos> Buscar(Permisos entidad)
        {
            return this.conexion.Permisos!
                .Where(x => x.Ventana!.Contains(entidad.Ventana!))
                .Include(x => x._Rol)
                .ToList();
        }

        public List<Permisos> Consultar()
        {
            return this.conexion.Permisos!
                .Include(x => x._Rol)
                .Take(20).ToList();
        }

        public Permisos Insertar(Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            if (this.conexion.Permisos!.Any(x => x.Rol == entidad.Rol && x.Ventana == entidad.Ventana))
                throw new Exception("Ese rol ya tiene permiso para " + entidad.Ventana);

            this.conexion.Permisos!.Add(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Permisos", "Insertar", entidad.Id);
            return entidad;
        }

        private bool Validar(Permisos entidad)
        {
            return string.IsNullOrEmpty(entidad.Ventana) ||
                entidad.Rol <= 0;
        }

        private void ValidarRelaciones(Permisos entidad)
        {
            if (!this.conexion.Roles!.Any(x => x.Id == entidad.Rol))
                throw new Exception("No existe Rol con Id " + entidad.Rol);
        }
    }
}
