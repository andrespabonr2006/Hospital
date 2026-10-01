using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class HistorialesPruebas
    {
        private IConexion conexion;
        private Historiales? entidad = null;

        public HistorialesPruebas()
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
            this.entidad = new Historiales()
            {
                FechaApertura = DateTime.Now,
                Antecedente = "Ninguno",
                Paciente = this.conexion.Pacientes!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Historiales!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Historiales!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Antecedente = "Asma";

            var entry = this.conexion!.Entry<Historiales>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Historiales!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}