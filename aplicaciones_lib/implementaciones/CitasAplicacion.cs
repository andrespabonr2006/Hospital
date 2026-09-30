using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class CitasAplicacion : ICitasAplicacion
    {
        private IConexion conexion;

        public CitasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Citas Actualizar(Citas entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Citas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Citas Borrar(Citas entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Citas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Citas> Consultar()
        {
            return this.conexion.Citas!.ToList();
        }

        public Citas Insertar(Citas entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Citas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
