using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class HistorialesAplicacion : IHistorialesAplicacion
    {
        private IConexion conexion;

        public HistorialesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Historiales Actualizar(Historiales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            var entry = this.conexion!.Entry<Historiales>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            Auditoria.Registrar(this.conexion, "Historiales", "Actualizar", entidad.Id);
            return entidad;
        }

        public Historiales Borrar(Historiales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.conexion.Historiales!.Remove(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Historiales", "Borrar", entidad.Id);
            return entidad;
        }

        public List<Historiales> Buscar(Historiales entidad)
        {
            return this.conexion.Historiales!
                .Where(x => x.Antecedente!.Contains(entidad.Antecedente!))
                .Include(x => x._Paciente)
                .ToList();
        }

        public List<Historiales> Consultar()
        {
            return this.conexion.Historiales!
                .Include(x => x._Paciente)
                .Take(5).ToList();
        }

        public Historiales Insertar(Historiales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            ValidarRelaciones(entidad);

            this.conexion.Historiales!.Add(entidad!);
            this.conexion.SaveChanges();
            Auditoria.Registrar(this.conexion, "Historiales", "Insertar", entidad.Id);
            return entidad;
        }

        private bool Validar(Historiales entidad)
        {
            return entidad.FechaApertura == null ||
                string.IsNullOrEmpty(entidad.Antecedente) ||
                entidad.Paciente <= 0;
        }

        private void ValidarRelaciones(Historiales entidad)
        {
            if (!this.conexion.Pacientes!.Any(x => x.Id == entidad.Paciente))
                throw new Exception("No existe Paciente con Id " + entidad.Paciente);
        }
    }
}
