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
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Administrativos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Administrativos Borrar(Administrativos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Administrativos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Administrativos> Consultar()
        {
            return this.conexion.Administrativos!.ToList();
        }

        public Administrativos Insertar(Administrativos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Administrativos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
