using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class ProcedimientosAplicacion : IProcedimientosAplicacion
    {
        private IConexion conexion;

        public ProcedimientosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Procedimientos Actualizar(Procedimientos entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Procedimientos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Procedimientos Borrar(Procedimientos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Procedimientos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Procedimientos> Consultar()
        {
            return this.conexion.Procedimientos!.ToList();
        }

        public Procedimientos Insertar(Procedimientos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Procedimientos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
