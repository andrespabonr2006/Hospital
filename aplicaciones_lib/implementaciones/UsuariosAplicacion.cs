using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion conexion;

        public UsuariosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Usuarios Actualizar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            // Si escribieron una contrasena nueva (no cifrada), se cifra antes de guardar
            if (!Cifrado.EstaCifrado(entidad.Contrasena))
                entidad.Contrasena = Cifrado.Sha256(entidad.Contrasena!);

            var entry = this.conexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Usuarios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Usuarios> Buscar(Usuarios entidad)
        {
            return this.conexion.Usuarios!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Include(x => x._Rol)
                .ToList();
        }

        public List<Usuarios> Consultar()
        {
            return this.conexion.Usuarios!
                .Include(x => x._Rol)
                .Take(5).ToList();
        }

        public Usuarios Insertar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            if (this.conexion.Usuarios!.Any(x => x.Correo == entidad.Correo))
                throw new Exception("Ya existe un usuario con el correo " + entidad.Correo);

            entidad.Contrasena = Cifrado.Sha256(entidad.Contrasena!);

            this.conexion.Usuarios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        // Busca un usuario activo con ese correo y esa contrasena (cifrada).
        // Devuelve null si los datos no coinciden.
        public Usuarios? Login(Usuarios entidad)
        {
            if (string.IsNullOrEmpty(entidad.Correo) ||
                string.IsNullOrEmpty(entidad.Contrasena))
                return null;

            var contrasena = Cifrado.Sha256(entidad.Contrasena);

            return this.conexion.Usuarios!
                .Include(x => x._Rol)
                .FirstOrDefault(x => x.Correo == entidad.Correo &&
                    x.Contrasena == contrasena &&
                    x.Activo);
        }

        private bool Validar(Usuarios entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Correo) ||
                string.IsNullOrEmpty(entidad.Contrasena) ||
                entidad.Rol <= 0;
        }

        private void ValidarRelaciones(Usuarios entidad)
        {
            if (!this.conexion.Roles!.Any(x => x.Id == entidad.Rol))
                throw new Exception("No existe Rol con Id " + entidad.Rol);
        }
    }
}
