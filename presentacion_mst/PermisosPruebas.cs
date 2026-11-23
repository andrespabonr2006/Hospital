using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class PermisosPruebas
    {
        private IConexion conexion;
        private Permisos? entidad = null;

        public PermisosPruebas()
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
            this.entidad = new Permisos()
            {
                Ventana = "Pacientes",
                Rol = this.conexion.Roles!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Permisos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Permisos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Ventana = "Citas";

            var entry = this.conexion!.Entry<Permisos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Permisos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
