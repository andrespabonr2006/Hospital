using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class MedicosAplicacion : IMedicosAplicacion
    {
        private IConexion conexion;

        public MedicosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Medicos Actualizar(Medicos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Medicos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Medicos Borrar(Medicos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Medicos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Medicos> Buscar(Medicos entidad)
        {
            return this.conexion.Medicos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Include(x => x._Sector)
                .ToList();
        }

        public List<Medicos> Consultar()
        {
            return this.conexion.Medicos!
                .Include(x => x._Sector)
                .Take(5).ToList();
        }

        public Medicos Insertar(Medicos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Medicos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Medicos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Especialidad) ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                entidad.Sector <= 0;
        }

        private void ValidarRelaciones(Medicos entidad)
        {
            if (!this.conexion.Sectores!.Any(x => x.Id == entidad.Sector))
                throw new Exception("No existe Sector con Id " + entidad.Sector);
        }
    }
}
