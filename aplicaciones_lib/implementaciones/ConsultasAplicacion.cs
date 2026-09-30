using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class ConsultasAplicacion : IConsultasAplicacion
    {
        private IConexion conexion;

        public ConsultasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Consultas Actualizar(Consultas entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Consultas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Consultas Borrar(Consultas entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Consultas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Consultas> Consultar()
        {
            return this.conexion.Consultas!.ToList();
        }

        public Consultas Insertar(Consultas entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Consultas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
