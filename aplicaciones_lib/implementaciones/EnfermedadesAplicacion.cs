using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class EnfermedadesAplicacion : IEnfermedadesAplicacion
    {
        private IConexion conexion;

        public EnfermedadesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Enfermedades Actualizar(Enfermedades entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Enfermedades>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Enfermedades Borrar(Enfermedades entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Enfermedades!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Enfermedades> Buscar(Enfermedades entidad)
        {
            return this.conexion.Enfermedades!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Include(x => x._Consulta)
                .ToList();
        }

        public List<Enfermedades> Consultar()
        {
            return this.conexion.Enfermedades!
                .Include(x => x._Consulta)
                .Take(5).ToList();
        }

        public Enfermedades Insertar(Enfermedades entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Enfermedades!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Enfermedades entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Categoria) ||
                string.IsNullOrEmpty(entidad.NivelContagio) ||
                entidad.Consulta <= 0;
        }

        private void ValidarRelaciones(Enfermedades entidad)
        {
            if (!this.conexion.Consultas!.Any(x => x.Id == entidad.Consulta))
                throw new Exception("No existe Consulta con Id " + entidad.Consulta);
        }
    }
}
