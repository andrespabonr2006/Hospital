using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class AuditoriasPresentacion : IAuditoriasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public AuditoriasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Auditorias> Buscar(Auditorias entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Auditorias>>(
                "Auditorias/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Auditorias> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Auditorias>>(
                "Auditorias/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Auditorias Insertar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Entidad) ||
                string.IsNullOrEmpty(entidad.Operacion))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Auditorias>(
                "Auditorias/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}
