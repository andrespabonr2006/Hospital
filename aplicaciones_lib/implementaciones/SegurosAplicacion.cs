using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class SegurosAplicacion : ISegurosAplicacion
    {
        private IConexion conexion;

        public SegurosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Seguros Actualizar(Seguros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Seguros>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Seguros Borrar(Seguros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Seguros!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Seguros> Buscar(Seguros entidad)
        {
            return this.conexion.Seguros!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Include(x => x._Solicitud)
                .ToList();
        }

        public List<Seguros> Consultar()
        {
            return this.conexion.Seguros!
                .Include(x => x._Solicitud)
                .Take(5).ToList();
        }

        public Seguros Insertar(Seguros entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Seguros!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Seguros entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.FechaVencimiento == null ||
                string.IsNullOrEmpty(entidad.Cobertura) ||
                entidad.Solicitud <= 0;
        }

        private void ValidarRelaciones(Seguros entidad)
        {
            if (!this.conexion.Solicitudes!.Any(x => x.Id == entidad.Solicitud))
                throw new Exception("No existe Solicitud con Id " + entidad.Solicitud);
        }
    }
}
