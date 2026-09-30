using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class EnfermedadesAplicacion : IEnfermedadesAplicacion
    {
        private IConexion conexion;

        public EnfermedadesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Enfermedades Actualizar(Enfermedades entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Enfermedades>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Enfermedades Borrar(Enfermedades entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Enfermedades!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Enfermedades> Consultar()
        {
            return this.conexion.Enfermedades!.ToList();
        }

        public Enfermedades Insertar(Enfermedades entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Enfermedades!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
