using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class SectoresPresentacion : ISectoresPresentacion
    {
        private IComunicaciones IComunicaciones;

        public SectoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Sectores Actualizar(Sectores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sectores>(
                "Sectores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Sectores Borrar(Sectores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Sectores>(
                "Sectores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Sectores> Buscar(Sectores entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Sectores>>(
                "Sectores/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Sectores> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Sectores>>(
                "Sectores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Sectores Insertar(Sectores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sectores>(
                "Sectores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Sectores entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion) ||
                entidad.Hospital <= 0;
        }
    }
}