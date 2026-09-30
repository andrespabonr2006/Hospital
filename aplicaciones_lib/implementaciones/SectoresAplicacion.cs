using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
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
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Sectores>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Sectores Borrar(Sectores entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Sectores!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Sectores> Consultar()
        {
            return this.conexion.Sectores!.ToList();
        }

        public Sectores Insertar(Sectores entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Sectores!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
