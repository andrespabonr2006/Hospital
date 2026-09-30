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
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Seguros>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Seguros Borrar(Seguros entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Seguros!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Seguros> Consultar()
        {
            return this.conexion.Seguros!.ToList();
        }

        public Seguros Insertar(Seguros entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Seguros!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
