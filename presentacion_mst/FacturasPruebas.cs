using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class FacturasPruebas
    {
        private IConexion conexion;
        private Facturas? entidad = null;

        public FacturasPruebas()
        {
            this.conexion = new Conexion();
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            this.entidad = new Facturas()
            {
                FechaEmision = DateTime.Now,
                Subtotal = 100000.00m,
                Impuesto = 19000.00m,
                Medicamento = this.conexion.Medicamentos!.OrderBy(x => x.Id).First().Id,
                Procedimiento = this.conexion.Procedimientos!.OrderBy(x => x.Id).First().Id,
                Administrativo = this.conexion.Administrativos!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Facturas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Facturas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Subtotal = 110000.00m;

            var entry = this.conexion!.Entry<Facturas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Facturas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
