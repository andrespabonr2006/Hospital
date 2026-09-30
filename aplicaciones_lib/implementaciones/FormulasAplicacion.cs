using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class FormulasAplicacion : IFormulasAplicacion
    {
        private IConexion conexion;

        public FormulasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Formulas Actualizar(Formulas entidad)
        {
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Formulas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Formulas Borrar(Formulas entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Formulas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Formulas> Consultar()
        {
            return this.conexion.Formulas!.ToList();
        }

        public Formulas Insertar(Formulas entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Formulas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
