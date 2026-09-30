using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class PacientesAplicacion : IPacientesAplicacion
    {
        private IConexion conexion;

        public PacientesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Pacientes Actualizar(Pacientes entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Pacientes>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Pacientes Borrar(Pacientes entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Pacientes!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Pacientes> Consultar()
        {
            return this.conexion.Pacientes!.ToList();
        }

        public Pacientes Insertar(Pacientes entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Pacientes!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}