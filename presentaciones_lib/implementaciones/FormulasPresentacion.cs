using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class FormulasPresentacion : IFormulasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public FormulasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Formulas Actualizar(Formulas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Formulas>(
                "Formulas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Formulas Borrar(Formulas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Formulas>(
                "Formulas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Formulas> Buscar(Formulas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Formulas>>(
                "Formulas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Formulas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Formulas>>(
                "Formulas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Formulas Insertar(Formulas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Formulas>(
                "Formulas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Formulas entidad)
        {
            return entidad.Fecha == null ||
                string.IsNullOrEmpty(entidad.Indicacion) ||
                string.IsNullOrEmpty(entidad.Vigencia) ||
                entidad.Consulta <= 0;
        }
    }
}