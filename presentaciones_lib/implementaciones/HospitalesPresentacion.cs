using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class HospitalesPresentacion : IHospitalesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public HospitalesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Hospitales Actualizar(Hospitales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Hospitales>(
                "Hospitales/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Hospitales Borrar(Hospitales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Hospitales>(
                "Hospitales/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Hospitales> Buscar(Hospitales entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Hospitales>>(
                "Hospitales/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Hospitales> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Hospitales>>(
                "Hospitales/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Hospitales Insertar(Hospitales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Hospitales>(
                "Hospitales/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Hospitales entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Direccion) ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                string.IsNullOrEmpty(entidad.Correo);
        }
    }
}