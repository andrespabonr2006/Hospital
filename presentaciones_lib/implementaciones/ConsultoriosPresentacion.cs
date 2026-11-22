using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class ConsultoriosPresentacion : IConsultoriosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ConsultoriosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Consultorios Actualizar(Consultorios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Consultorios>(
                "Consultorios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Consultorios Borrar(Consultorios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Consultorios>(
                "Consultorios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Consultorios> Buscar(Consultorios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Consultorios>>(
                "Consultorios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Consultorios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Consultorios>>(
                "Consultorios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Consultorios Insertar(Consultorios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Consultorios>(
                "Consultorios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Consultorios entidad)
        {
            return string.IsNullOrEmpty(entidad.Estado) ||
                string.IsNullOrEmpty(entidad.Equipamiento) ||
                entidad.Sector <= 0 ||
                entidad.Medico <= 0;
        }
    }
}