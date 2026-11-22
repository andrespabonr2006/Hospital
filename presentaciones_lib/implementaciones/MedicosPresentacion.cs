using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class MedicosPresentacion : IMedicosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public MedicosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Medicos Actualizar(Medicos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Medicos>(
                "Medicos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Medicos Borrar(Medicos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Medicos>(
                "Medicos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Medicos> Buscar(Medicos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Medicos>>(
                "Medicos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Medicos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Medicos>>(
                "Medicos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Medicos Insertar(Medicos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Medicos>(
                "Medicos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Medicos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Especialidad) ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                entidad.Sector <= 0;
        }
    }
}