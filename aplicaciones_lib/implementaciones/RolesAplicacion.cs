using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion conexion;

        public RolesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (this.conexion.Usuarios!.Any(x => x.Rol == entidad.Id))
                throw new Exception("No se puede borrar: hay usuarios con este rol");

            this.conexion.Roles!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Roles> Buscar(Roles entidad)
        {
            return this.conexion.Roles!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Roles> Consultar()
        {
            return this.conexion.Roles!.Take(20).ToList();
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Roles!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Roles entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
