using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class ProcedimientosPruebas
    {
        private IConexion conexion;
        private Procedimientos? entidad = null;

        public ProcedimientosPruebas()
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
            this.entidad = new Procedimientos()
            {
                Proceso = "Radiografia",
                Duracion = "30 minutos",
                Costo = 120000.00m,
                Examen = this.conexion.Examenes!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Procedimientos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Procedimientos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Costo = 130000.00m;

            var entry = this.conexion!.Entry<Procedimientos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Procedimientos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
