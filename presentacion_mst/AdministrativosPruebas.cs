using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class AdministrativosPruebas
    {
        private IConexion conexion;
        private Administrativos? entidad = null;

        public AdministrativosPruebas()
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
            this.entidad = new Administrativos()
            {
                Nombre = "Ana Torres",
                Cargo = "Facturacion",
                Telefono = "3027778899",
                Hospital = this.conexion.Hospitales!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Administrativos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Administrativos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cargo = "Recepcion";

            var entry = this.conexion!.Entry<Administrativos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Administrativos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
