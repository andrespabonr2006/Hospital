using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class SegurosPruebas
    {
        private IConexion conexion;
        private Seguros? entidad = null;

        public SegurosPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
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
            this.entidad = new Seguros()
            {
                Nombre = "Sura",
                FechaVencimiento = DateTime.Now.AddYears(1),
                Cobertura = "Total",
                Solicitud = this.conexion.Solicitudes!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Seguros!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Seguros!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cobertura = "Parcial";

            var entry = this.conexion!.Entry<Seguros>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Seguros!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
