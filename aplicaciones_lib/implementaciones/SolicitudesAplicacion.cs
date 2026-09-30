using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class SolicitudesAplicacion : ISolicitudesAplicacion
    {
        private IConexion conexion;

        public SolicitudesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Solicitudes Actualizar(Solicitudes entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Solicitudes>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Solicitudes Borrar(Solicitudes entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Solicitudes!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Solicitudes> Consultar()
        {
            return this.conexion.Solicitudes!.ToList();
        }

        public Solicitudes Insertar(Solicitudes entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Solicitudes!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
