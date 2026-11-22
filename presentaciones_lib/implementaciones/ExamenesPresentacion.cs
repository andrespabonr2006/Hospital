using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class ExamenesPresentacion : IExamenesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ExamenesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Examenes Actualizar(Examenes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Examenes>(
                "Examenes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Examenes Borrar(Examenes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Examenes>(
                "Examenes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Examenes> Buscar(Examenes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Examenes>>(
                "Examenes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Examenes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Examenes>>(
                "Examenes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Examenes Insertar(Examenes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Examenes>(
                "Examenes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Examenes entidad)
        {
            return string.IsNullOrEmpty(entidad.Tipo) ||
                string.IsNullOrEmpty(entidad.Resultado) ||
                entidad.Fecha == null ||
                entidad.Formula <= 0;
        }
    }
}