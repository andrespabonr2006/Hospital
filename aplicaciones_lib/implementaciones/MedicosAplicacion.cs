using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class MedicosAplicacion : IMedicosAplicacion
    {
        private IConexion conexion;

        public MedicosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Medicos Actualizar(Medicos entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Medicos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Medicos Borrar(Medicos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Medicos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Medicos> Consultar()
        {
            return this.conexion.Medicos!.ToList();
        }

        public Medicos Insertar(Medicos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Medicos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
