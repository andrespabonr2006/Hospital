using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class ConsultasPruebas
    {
        private IConexion conexion;
        private Consultas? entidad = null;

        public ConsultasPruebas()
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
            this.entidad = new Consultas()
            {
                Observacion = "Paciente estable",
                SignosVitales = "Presion 120/80",
                CostoConsulta = 45000.00m,
                Cita = this.conexion.Citas!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Consultas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Consultas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.CostoConsulta = 50000.00m;

            var entry = this.conexion!.Entry<Consultas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Consultas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}