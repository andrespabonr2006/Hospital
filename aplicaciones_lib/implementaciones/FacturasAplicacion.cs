using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private IConexion conexion;

        public FacturasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Facturas Actualizar(Facturas entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Facturas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Facturas Borrar(Facturas entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Facturas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Facturas> Consultar()
        {
            return this.conexion.Facturas!.ToList();
        }

        public Facturas Insertar(Facturas entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Facturas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
