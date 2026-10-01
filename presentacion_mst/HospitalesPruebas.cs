using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class HospitalesPruebas
    {
        private IConexion conexion;
        private Hospitales? entidad = null;

        public HospitalesPruebas()
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
            this.entidad = new Hospitales()
            {
                Nombre = "Hospital General Prueba",
                Direccion = "Calle 10 # 20-30",
                Telefono = "6044441234",
                Correo = "contacto@hospital.com",
            };
            this.conexion.Hospitales!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Hospitales!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Correo = "nuevo@hospital.com";

            var entry = this.conexion!.Entry<Hospitales>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Hospitales!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
