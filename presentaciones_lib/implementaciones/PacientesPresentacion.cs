using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

namespace aplicaciones_lib.implementaciones
{
    public class PacientesPresentacion : IPacientesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public PacientesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Pacientes Actualizar(Pacientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Pacientes>(
                "Pacientes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Pacientes Borrar(Pacientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Pacientes>(
                "Pacientes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Pacientes> Buscar(Pacientes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Pacientes>>(
                "Pacientes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Pacientes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Pacientes>>(
                "Pacientes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Pacientes Insertar(Pacientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Pacientes>(
                "Pacientes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Pacientes entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.FechaNacimiento == null ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                string.IsNullOrEmpty(entidad.Direccion);
        }
    }
}