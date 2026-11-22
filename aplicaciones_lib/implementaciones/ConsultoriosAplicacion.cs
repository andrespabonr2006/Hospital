using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class ConsultoriosAplicacion : IConsultoriosAplicacion
    {
        private IConexion conexion;

        public ConsultoriosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Consultorios Actualizar(Consultorios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Consultorios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Consultorios Borrar(Consultorios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Consultorios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Consultorios> Buscar(Consultorios entidad)
        {
            return this.conexion.Consultorios!
                .Where(x => x.Estado!.Contains(entidad.Estado!))
                .Include(x => x._Sector).Include(x => x._Medico)
                .ToList();
        }

        public List<Consultorios> Consultar()
        {
            return this.conexion.Consultorios!
                .Include(x => x._Sector).Include(x => x._Medico)
                .Take(5).ToList();
        }

        public Consultorios Insertar(Consultorios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Consultorios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Consultorios entidad)
        {
            return string.IsNullOrEmpty(entidad.Estado) ||
                string.IsNullOrEmpty(entidad.Equipamiento) ||
                entidad.Sector <= 0 ||
                entidad.Medico <= 0;
        }

        private void ValidarRelaciones(Consultorios entidad)
        {
            if (!this.conexion.Sectores!.Any(x => x.Id == entidad.Sector))
                throw new Exception("No existe Sector con Id " + entidad.Sector);

            if (!this.conexion.Medicos!.Any(x => x.Id == entidad.Medico))
                throw new Exception("No existe Medico con Id " + entidad.Medico);
        }
    }
}
