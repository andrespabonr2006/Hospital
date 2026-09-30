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
            // Hacer calculo o operaciones

            var entry = this.conexion!.Entry<Hospitales>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Hospitales Borrar(Hospitales entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Hospitales!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Hospitales> Consultar()
        {
            return this.conexion.Hospitales!.ToList();
        }

        public Hospitales Insertar(Hospitales entidad)
        {
            // Hacer calculo o operaciones

            this.conexion.Hospitales!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}