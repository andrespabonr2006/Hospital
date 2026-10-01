using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class SectoresPruebas
    {
        private IConexion conexion;
        private Sectores? entidad = null;

        public SectoresPruebas()
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
            this.entidad = new Sectores()
            {
                Nombre = "Urgencias",
                Piso = 1,
                Descripcion = "Atencion inmediata",
                Hospital = this.conexion.Hospitales!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Sectores!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Sectores!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Piso = 2;

            var entry = this.conexion!.Entry<Sectores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Sectores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}