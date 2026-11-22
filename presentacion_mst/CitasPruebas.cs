using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class CitasPruebas
    {
        private IConexion conexion;
        private Citas? entidad = null;

        public CitasPruebas()
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
            this.entidad = new Citas()
            {
                Fecha = DateTime.Now,
                Estado = "Pendiente",
                Solicitud = this.conexion.Solicitudes!.OrderBy(x => x.Id).First().Id,
                Paciente = this.conexion.Pacientes!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Citas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Citas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = "Atendida";

            var entry = this.conexion!.Entry<Citas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Citas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}