using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class FormulasPruebas
    {
        private IConexion conexion;
        private Formulas? entidad = null;

        public FormulasPruebas()
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
            this.entidad = new Formulas()
            {
                Fecha = DateTime.Now,
                Indicacion = "Acetaminofen cada 8 horas",
                Vigencia = "30 dias",
                Consulta = this.conexion.Consultas!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Formulas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Formulas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Vigencia = "15 dias";

            var entry = this.conexion!.Entry<Formulas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Formulas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
