using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class SolicitudesPruebas
    {
        private IConexion conexion;
        private Solicitudes? entidad = null;

        public SolicitudesPruebas()
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
            this.entidad = new Solicitudes()
            {
                Fecha = DateTime.Now,
                NivelUrgencia = "Media",
                Motivo = "Dolor de cabeza",
                Paciente = this.conexion.Pacientes!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Solicitudes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Solicitudes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.NivelUrgencia = "Alta";

            var entry = this.conexion!.Entry<Solicitudes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Solicitudes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}