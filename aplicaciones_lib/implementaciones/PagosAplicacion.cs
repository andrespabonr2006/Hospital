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
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Pagos Borrar(Pagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Pagos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Buscar(Pagos entidad)
        {
            return this.conexion.Pagos!
                .Where(x => x.Metodo!.Contains(entidad.Metodo!))
                .Include(x => x._Factura)
                .ToList();
        }

        public List<Pagos> Consultar()
        {
            return this.conexion.Pagos!
                .Include(x => x._Factura)
                .Take(5).ToList();
        }

        public Pagos Insertar(Pagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Pagos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Pagos entidad)
        {
            return string.IsNullOrEmpty(entidad.Metodo) ||
                entidad.Fecha == null ||
                entidad.Factura <= 0;
        }

        private void ValidarRelaciones(Pagos entidad)
        {
            if (!this.conexion.Facturas!.Any(x => x.Id == entidad.Factura))
                throw new Exception("No existe Factura con Id " + entidad.Factura);
        }
    }
}
