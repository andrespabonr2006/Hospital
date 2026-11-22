using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private IConexion conexion;

        public FacturasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Facturas Actualizar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Facturas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }

        public Facturas Borrar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Facturas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Facturas> Buscar(Facturas entidad)
        {
            return this.conexion.Facturas!
                .Include(x => x._Medicamento).Include(x => x._Procedimiento).Include(x => x._Administrativo)
                .ToList();
        }

        public List<Facturas> Consultar()
        {
            return this.conexion.Facturas!
                .Include(x => x._Medicamento).Include(x => x._Procedimiento).Include(x => x._Administrativo)
                .Take(5).ToList();
        }

        public Facturas Insertar(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Facturas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Facturas entidad)
        {
            return entidad.FechaEmision == null ||
                entidad.Medicamento <= 0 ||
                entidad.Procedimiento <= 0 ||
                entidad.Administrativo <= 0;
        }

        private void ValidarRelaciones(Facturas entidad)
        {
            if (!this.conexion.Medicamentos!.Any(x => x.Id == entidad.Medicamento))
                throw new Exception("No existe Medicamento con Id " + entidad.Medicamento);

            if (!this.conexion.Procedimientos!.Any(x => x.Id == entidad.Procedimiento))
                throw new Exception("No existe Procedimiento con Id " + entidad.Procedimiento);

            if (!this.conexion.Administrativos!.Any(x => x.Id == entidad.Administrativo))
                throw new Exception("No existe Administrativo con Id " + entidad.Administrativo);
        }
    }
}
