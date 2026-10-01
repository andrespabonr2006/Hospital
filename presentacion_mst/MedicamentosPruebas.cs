using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class MedicamentosPruebas
    {
        private IConexion conexion;
        private Medicamentos? entidad = null;

        public MedicamentosPruebas()
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
            this.entidad = new Medicamentos()
            {
                NombreComercial = "Dolex",
                Dosis = "500 mg",
                Disponibilidad = 100,
            };
            this.conexion.Medicamentos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Medicamentos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Disponibilidad = 90;

            var entry = this.conexion!.Entry<Medicamentos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Medicamentos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
