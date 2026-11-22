using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class TurnosPresentacion : ITurnosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public TurnosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Turnos Actualizar(Turnos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Turnos>(
                "Turnos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Turnos Borrar(Turnos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Turnos>(
                "Turnos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Turnos> Buscar(Turnos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Turnos>>(
                "Turnos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Turnos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Turnos>>(
                "Turnos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Turnos Insertar(Turnos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Turnos>(
                "Turnos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Turnos entidad)
        {
            return string.IsNullOrEmpty(entidad.Jornada) ||
                entidad.HoraInicio == null ||
                entidad.HoraFinal == null ||
                entidad.Medico <= 0;
        }
    }
}