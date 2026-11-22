using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class EnfermedadesPruebas
    {
        private IConexion conexion;
        private Enfermedades? entidad = null;

        public EnfermedadesPruebas()
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
            this.entidad = new Enfermedades()
            {
                Nombre = "Gripa",
                Categoria = "Respiratoria",
                NivelContagio = "Alto",
                Consulta = this.conexion.Consultas!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Enfermedades!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Enfermedades!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.NivelContagio = "Medio";

            var entry = this.conexion!.Entry<Enfermedades>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Enfermedades!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}