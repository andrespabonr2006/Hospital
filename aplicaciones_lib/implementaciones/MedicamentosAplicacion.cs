using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class MedicamentosAplicacion : IMedicamentosAplicacion
    {
        private IConexion conexion;

        public MedicamentosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Medicamentos Actualizar(Medicamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.conexion!.Entry<Medicamentos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Medicamentos Borrar(Medicamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Medicamentos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Medicamentos> Buscar(Medicamentos entidad)
        {
            return this.conexion.Medicamentos!
                .Where(x => x.NombreComercial!.Contains(entidad.NombreComercial!))
                .ToList();
        }

        public List<Medicamentos> Consultar()
        {
            return this.conexion.Medicamentos!.Take(5).ToList();
        }

        public Medicamentos Insertar(Medicamentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.conexion.Medicamentos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Medicamentos entidad)
        {
            return string.IsNullOrEmpty(entidad.NombreComercial) ||
                string.IsNullOrEmpty(entidad.Dosis);
        }
    }
}
