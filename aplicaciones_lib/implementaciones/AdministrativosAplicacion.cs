using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class AdministrativosAplicacion : IAdministrativosAplicacion
    {
        private IConexion conexion;

        public AdministrativosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Administrativos Actualizar(Administrativos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Administrativos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Administrativos Borrar(Administrativos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Administrativos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Administrativos> Buscar(Administrativos entidad)
        {
            return this.conexion.Administrativos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Include(x => x._Hospital)
                .ToList();
        }

        public List<Administrativos> Consultar()
        {
            return this.conexion.Administrativos!
                .Include(x => x._Hospital)
                .Take(5).ToList();
        }

        public Administrativos Insertar(Administrativos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Administrativos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Administrativos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Cargo) ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                entidad.Hospital <= 0;
        }

        private void ValidarRelaciones(Administrativos entidad)
        {
            if (!this.conexion.Hospitales!.Any(x => x.Id == entidad.Hospital))
                throw new Exception("No existe Hospital con Id " + entidad.Hospital);
        }
    }
}
