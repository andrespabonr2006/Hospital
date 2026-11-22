using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class SolicitudesPresentacion : ISolicitudesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public SolicitudesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Solicitudes Actualizar(Solicitudes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Solicitudes>(
                "Solicitudes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Solicitudes Borrar(Solicitudes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Solicitudes>(
                "Solicitudes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Solicitudes> Buscar(Solicitudes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Solicitudes>>(
                "Solicitudes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Solicitudes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Solicitudes>>(
                "Solicitudes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Solicitudes Insertar(Solicitudes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Solicitudes>(
                "Solicitudes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Solicitudes entidad)
        {
            return entidad.Fecha == null ||
                string.IsNullOrEmpty(entidad.NivelUrgencia) ||
                string.IsNullOrEmpty(entidad.Motivo) ||
                entidad.Paciente <= 0;
        }
    }
}