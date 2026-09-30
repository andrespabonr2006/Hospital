using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class HistorialesAplicacion : IHistorialesAplicacion
    {
        private IConexion conexion;

        public HistorialesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Historiales Actualizar(Historiales entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Historiales>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Historiales Borrar(Historiales entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Historiales!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Historiales> Consultar()
        {
            return this.conexion.Historiales!.ToList();
        }

        public Historiales Insertar(Historiales entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Historiales!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}