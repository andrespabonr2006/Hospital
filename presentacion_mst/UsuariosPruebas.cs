using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace presentacion_mst
{
    [TestClass]
    public class UsuariosPruebas
    {
        private IConexion conexion;
        private Usuarios? entidad = null;

        public UsuariosPruebas()
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
            this.entidad = new Usuarios()
            {
                Nombre = "Usuario de prueba",
                Correo = "prueba" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                Contrasena = Cifrado.Sha256("123"),
                Activo = true,
                Rol = this.conexion.Roles!.OrderBy(x => x.Id).First().Id,
            };
            this.conexion.Usuarios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Usuarios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Activo = false;

            var entry = this.conexion!.Entry<Usuarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Usuarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
