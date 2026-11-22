using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class ConsultasPresentacion : IConsultasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ConsultasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Consultas Actualizar(Consultas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Consultas>(
                "Consultas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Consultas Borrar(Consultas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Consultas>(
                "Consultas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Consultas> Buscar(Consultas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Consultas>>(
                "Consultas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Consultas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Consultas>>(
                "Consultas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Consultas Insertar(Consultas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Consultas>(
                "Consultas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Consultas entidad)
        {
            return string.IsNullOrEmpty(entidad.Observacion) ||
                string.IsNullOrEmpty(entidad.SignosVitales) ||
                entidad.Cita <= 0;
        }
    }
}