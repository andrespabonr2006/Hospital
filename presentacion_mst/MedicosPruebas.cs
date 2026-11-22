using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class MedicosPruebas
    {
        private IConexion conexion;
        private Medicos? entidad = null;

        public MedicosPruebas()
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
            this.entidad = new Medicos()
            {
                Nombre = "Laura Restrepo",
                Especialidad = "Pediatria",
                Telefono = "3015556677",
                Sector = this.conexion.Sectores!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Medicos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Medicos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Especialidad = "Medicina general";

            var entry = this.conexion!.Entry<Medicos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Medicos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}