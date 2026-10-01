using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class HabitacionesPruebas
    {
        private IConexion conexion;
        private Habitaciones? entidad = null;

        public HabitacionesPruebas()
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
            this.entidad = new Habitaciones()
            {
                Tipo = "Individual",
                Disponibilidad = true,
                Sector = this.conexion.Sectores!.OrderBy(x => x.Id).First().Id,
                Paciente = this.conexion.Pacientes!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Habitaciones!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Habitaciones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Disponibilidad = false;

            var entry = this.conexion!.Entry<Habitaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Habitaciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}