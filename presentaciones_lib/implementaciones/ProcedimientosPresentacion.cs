using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class ProcedimientosPresentacion : IProcedimientosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ProcedimientosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Procedimientos Actualizar(Procedimientos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Procedimientos>(
                "Procedimientos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Procedimientos Borrar(Procedimientos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Procedimientos>(
                "Procedimientos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Procedimientos> Buscar(Procedimientos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Procedimientos>>(
                "Procedimientos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Procedimientos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Procedimientos>>(
                "Procedimientos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Procedimientos Insertar(Procedimientos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Procedimientos>(
                "Procedimientos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Procedimientos entidad)
        {
            return string.IsNullOrEmpty(entidad.Proceso) ||
                string.IsNullOrEmpty(entidad.Duracion) ||
                entidad.Examen <= 0;
        }
    }
}