using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class FacturasPresentacion : IFacturasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public FacturasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Facturas Actualizar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Facturas>(
                "Facturas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Facturas Borrar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Facturas>(
                "Facturas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Facturas> Buscar(Facturas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Facturas>>(
                "Facturas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Facturas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Facturas>>(
                "Facturas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Facturas Insertar(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Facturas>(
                "Facturas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Facturas entidad)
        {
            return entidad.FechaEmision == null ||
                entidad.Medicamento <= 0 ||
                entidad.Procedimiento <= 0 ||
                entidad.Administrativo <= 0;
        }
    }
}