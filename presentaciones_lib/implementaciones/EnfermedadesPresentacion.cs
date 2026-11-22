using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class EnfermedadesPresentacion : IEnfermedadesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public EnfermedadesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Enfermedades Actualizar(Enfermedades entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Enfermedades>(
                "Enfermedades/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Enfermedades Borrar(Enfermedades entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Enfermedades>(
                "Enfermedades/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Enfermedades> Buscar(Enfermedades entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Enfermedades>>(
                "Enfermedades/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Enfermedades> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Enfermedades>>(
                "Enfermedades/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Enfermedades Insertar(Enfermedades entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Enfermedades>(
                "Enfermedades/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Enfermedades entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Categoria) ||
                string.IsNullOrEmpty(entidad.NivelContagio) ||
                entidad.Consulta <= 0;
        }
    }
}