using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class ConsultoriosPruebas
    {
        private IConexion conexion;
        private Consultorios? entidad = null;

        public ConsultoriosPruebas()
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
            this.entidad = new Consultorios()
            {
                Estado = "Libre",
                Equipamiento = "Camilla, tensiometro",
                Sector = this.conexion.Sectores!.OrderBy(x => x.Id).First().Id,
                Medico = this.conexion.Medicos!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Consultorios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Consultorios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = "Ocupado";

            var entry = this.conexion!.Entry<Consultorios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Consultorios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}