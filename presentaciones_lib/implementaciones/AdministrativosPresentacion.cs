using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class AdministrativosPresentacion : IAdministrativosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public AdministrativosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Administrativos Actualizar(Administrativos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Administrativos>(
                "Administrativos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Administrativos Borrar(Administrativos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Administrativos>(
                "Administrativos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Administrativos> Buscar(Administrativos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Administrativos>>(
                "Administrativos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Administrativos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Administrativos>>(
                "Administrativos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Administrativos Insertar(Administrativos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Administrativos>(
                "Administrativos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Administrativos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Cargo) ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                entidad.Hospital <= 0;
        }
    }
}