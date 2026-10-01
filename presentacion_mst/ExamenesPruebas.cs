using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class ExamenesPruebas
    {
        private IConexion conexion;
        private Examenes? entidad = null;

        public ExamenesPruebas()
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
            this.entidad = new Examenes()
            {
                Tipo = "Sangre",
                Resultado = "Normal",
                Fecha = DateTime.Now,
                Formula = this.conexion.Formulas!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Examenes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Examenes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Resultado = "Revisar";

            var entry = this.conexion!.Entry<Examenes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Examenes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}