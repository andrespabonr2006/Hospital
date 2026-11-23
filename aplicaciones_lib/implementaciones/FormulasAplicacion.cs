using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
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
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Formulas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            Auditoria.Registrar(this.conexion, "Formulas", "Actualizar", entidad.Id);
            return entidad;
        }

        public Formulas Borrar(Formulas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Formulas!.Remove(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Formulas", "Borrar", entidad.Id);
            return entidad;
        }

        public List<Formulas> Buscar(Formulas entidad)
        {
            return this.conexion.Formulas!
                .Where(x => x.Indicacion!.Contains(entidad.Indicacion!))
                .Include(x => x._Consulta)
                .ToList();
        }

        public List<Formulas> Consultar()
        {
            return this.conexion.Formulas!
                .Include(x => x._Consulta)
                .Take(5).ToList();
        }

        public Formulas Insertar(Formulas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Formulas!.Add(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Formulas", "Insertar", entidad.Id);
            return entidad;
        }

        private bool Validar(Formulas entidad)
        {
            return entidad.Fecha == null ||
                string.IsNullOrEmpty(entidad.Indicacion) ||
                string.IsNullOrEmpty(entidad.Vigencia) ||
                entidad.Consulta <= 0;
        }

        private void ValidarRelaciones(Formulas entidad)
        {
            if (!this.conexion.Consultas!.Any(x => x.Id == entidad.Consulta))
                throw new Exception("No existe Consulta con Id " + entidad.Consulta);
        }
    }
}
