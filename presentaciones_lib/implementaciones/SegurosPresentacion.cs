using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class SegurosPresentacion : ISegurosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public SegurosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Seguros Actualizar(Seguros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Seguros>(
                "Seguros/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Seguros Borrar(Seguros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Seguros>(
                "Seguros/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Seguros> Buscar(Seguros entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Seguros>>(
                "Seguros/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Seguros> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Seguros>>(
                "Seguros/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Seguros Insertar(Seguros entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Seguros>(
                "Seguros/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Seguros entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.FechaVencimiento == null ||
                string.IsNullOrEmpty(entidad.Cobertura) ||
                entidad.Solicitud <= 0;
        }
    }
}