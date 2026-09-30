using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion conexion;

        public PagosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Pagos Actualizar(Pagos entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Pagos Borrar(Pagos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Pagos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Consultar()
        {
            return this.conexion.Pagos!.ToList();
        }

        public Pagos Insertar(Pagos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Pagos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
