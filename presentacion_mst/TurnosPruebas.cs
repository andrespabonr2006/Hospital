using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class TurnosPruebas
    {
        private IConexion conexion;
        private Turnos? entidad = null;

        public TurnosPruebas()
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
            this.entidad = new Turnos()
            {
                Jornada = "Manana",
                HoraInicio = DateTime.Now,
                HoraFinal = DateTime.Now.AddHours(8),
                Medico = this.conexion.Medicos!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Turnos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Turnos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Jornada = "Noche";

            var entry = this.conexion!.Entry<Turnos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Turnos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}