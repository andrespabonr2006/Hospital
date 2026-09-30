using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class MedicamentosAplicacion : IMedicamentosAplicacion
    {
        private IConexion conexion;

        public MedicamentosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Medicamentos Actualizar(Medicamentos entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Medicamentos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Medicamentos Borrar(Medicamentos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Medicamentos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Medicamentos> Consultar()
        {
            return this.conexion.Medicamentos!.ToList();
        }

        public Medicamentos Insertar(Medicamentos entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Medicamentos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
