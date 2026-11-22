using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class HistorialesPresentacion : IHistorialesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public HistorialesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Historiales Actualizar(Historiales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Historiales>(
                "Historiales/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Historiales Borrar(Historiales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Historiales>(
                "Historiales/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Historiales> Buscar(Historiales entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Historiales>>(
                "Historiales/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Historiales> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Historiales>>(
                "Historiales/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Historiales Insertar(Historiales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Historiales>(
                "Historiales/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Historiales entidad)
        {
            return entidad.FechaApertura == null ||
                string.IsNullOrEmpty(entidad.Antecedente) ||
                entidad.Paciente <= 0;
        }
    }
}