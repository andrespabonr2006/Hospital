using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class MedicamentosPresentacion : IMedicamentosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public MedicamentosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Medicamentos Actualizar(Medicamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Medicamentos>(
                "Medicamentos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Medicamentos Borrar(Medicamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Medicamentos>(
                "Medicamentos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Medicamentos> Buscar(Medicamentos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Medicamentos>>(
                "Medicamentos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Medicamentos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Medicamentos>>(
                "Medicamentos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Medicamentos Insertar(Medicamentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Medicamentos>(
                "Medicamentos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Medicamentos entidad)
        {
            return string.IsNullOrEmpty(entidad.NombreComercial) ||
                string.IsNullOrEmpty(entidad.Dosis);
        }
    }
}