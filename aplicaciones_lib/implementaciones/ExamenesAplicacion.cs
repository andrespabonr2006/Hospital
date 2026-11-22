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
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Examenes>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Examenes Borrar(Examenes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Examenes!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Examenes> Buscar(Examenes entidad)
        {
            return this.conexion.Examenes!
                .Where(x => x.Tipo!.Contains(entidad.Tipo!))
                .Include(x => x._Formula)
                .ToList();
        }

        public List<Examenes> Consultar()
        {
            return this.conexion.Examenes!
                .Include(x => x._Formula)
                .Take(5).ToList();
        }

        public Examenes Insertar(Examenes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Examenes!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Examenes entidad)
        {
            return string.IsNullOrEmpty(entidad.Tipo) ||
                string.IsNullOrEmpty(entidad.Resultado) ||
                entidad.Fecha == null ||
                entidad.Formula <= 0;
        }

        private void ValidarRelaciones(Examenes entidad)
        {
            if (!this.conexion.Formulas!.Any(x => x.Id == entidad.Formula))
                throw new Exception("No existe Formula con Id " + entidad.Formula);
        }
    }
}
