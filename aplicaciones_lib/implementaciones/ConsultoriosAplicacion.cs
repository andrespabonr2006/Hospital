using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class ConsultoriosAplicacion : IConsultoriosAplicacion
    {
        private IConexion conexion;

        public ConsultoriosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Consultorios Actualizar(Consultorios entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Consultorios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Consultorios Borrar(Consultorios entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Consultorios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Consultorios> Consultar()
        {
            return this.conexion.Consultorios!.ToList();
        }

        public Consultorios Insertar(Consultorios entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Consultorios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
