using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class AuditoriasAplicacion : IAuditoriasAplicacion
    {
        private IConexion conexion;

        public AuditoriasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Auditorias> Buscar(Auditorias entidad)
        {
            return this.conexion.Auditorias!
                .Where(x => x.Entidad!.Contains(entidad.Entidad!))
                .OrderByDescending(x => x.Fecha)
                .Take(50)
                .ToList();
        }

        public List<Auditorias> Consultar()
        {
            return this.conexion.Auditorias!
                .OrderByDescending(x => x.Fecha)
                .Take(20)
                .ToList();
        }

        public Auditorias Insertar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            entidad.Fecha = DateTime.Now;
            this.conexion.Auditorias!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Auditorias entidad)
        {
            return string.IsNullOrEmpty(entidad.Entidad) ||
                string.IsNullOrEmpty(entidad.Operacion);
        }
    }
}
