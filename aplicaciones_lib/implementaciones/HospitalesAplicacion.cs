using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class HospitalesAplicacion : IHospitalesAplicacion
    {
        private IConexion conexion;

        public HospitalesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Hospitales Actualizar(Hospitales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Hospitales>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Hospitales Borrar(Hospitales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Hospitales!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Hospitales> Buscar(Hospitales entidad)
        {
            return this.conexion.Hospitales!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Hospitales> Consultar()
        {
            return this.conexion.Hospitales!.Take(5).ToList();
        }

        public Hospitales Insertar(Hospitales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Hospitales!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
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
