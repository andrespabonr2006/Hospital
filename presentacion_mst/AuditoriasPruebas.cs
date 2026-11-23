using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class AuditoriasPruebas
    {
        private IConexion conexion;
        private Auditorias? entidad = null;

        public AuditoriasPruebas()
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
            this.entidad = new Auditorias()
            {
                Entidad = "Pruebas",
                Operacion = "Insertar",
                Registro = 0,
                Fecha = DateTime.Now,
            };
            this.conexion.Auditorias!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Auditorias!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Operacion = "Actualizar";

            var entry = this.conexion!.Entry<Auditorias>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Auditorias!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
