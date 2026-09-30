using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class ExamenesAplicacion : IExamenesAplicacion
    {
        private IConexion conexion;

        public ExamenesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Examenes Actualizar(Examenes entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Examenes>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Examenes Borrar(Examenes entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Examenes!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Examenes> Consultar()
        {
            return this.conexion.Examenes!.ToList();
        }

        public Examenes Insertar(Examenes entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Examenes!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
