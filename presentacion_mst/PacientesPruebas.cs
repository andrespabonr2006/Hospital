using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class PacientesPruebas
    {
        private IConexion conexion;
        private Pacientes? entidad = null;

        public PacientesPruebas()
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
            this.entidad = new Pacientes()
            {
                Nombre = "Juan Perez",
                FechaNacimiento = new DateTime(2000, 5, 20),
                Telefono = "3001234567",
                Direccion = "Carrera 45 # 12-80",
            };
            this.conexion.Pacientes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Pacientes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "3109876543";

            var entry = this.conexion!.Entry<Pacientes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Pacientes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}