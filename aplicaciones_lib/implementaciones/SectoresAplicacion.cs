using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class SectoresAplicacion : ISectoresAplicacion
    {
        private IConexion conexion;

        public SectoresAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Sectores Actualizar(Sectores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Sectores>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            Auditoria.Registrar(this.conexion, "Sectores", "Actualizar", entidad.Id);
            return entidad;
        }

        public Sectores Borrar(Sectores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Sectores!.Remove(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Sectores", "Borrar", entidad.Id);
            return entidad;
        }

        public List<Sectores> Buscar(Sectores entidad)
        {
            return this.conexion.Sectores!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Include(x => x._Hospital)
                .ToList();
        }

        public List<Sectores> Consultar()
        {
            return this.conexion.Sectores!
                .Include(x => x._Hospital)
                .Take(5).ToList();
        }

        public Sectores Insertar(Sectores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Sectores!.Add(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Sectores", "Insertar", entidad.Id);
            return entidad;
        }

        private bool Validar(Sectores entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion) ||
                entidad.Hospital <= 0;
        }

        private void ValidarRelaciones(Sectores entidad)
        {
            if (!this.conexion.Hospitales!.Any(x => x.Id == entidad.Hospital))
                throw new Exception("No existe Hospital con Id " + entidad.Hospital);
        }
    }
}
