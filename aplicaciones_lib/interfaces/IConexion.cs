using aplicaciones_lib.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace aplicaciones_lib.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Hospitales>? Hospitales { get; set; }
        DbSet<Pacientes>? Pacientes { get; set; }
        DbSet<Sectores>? Sectores { get; set; }
        DbSet<Medicos>? Medicos { get; set; }
        DbSet<Turnos>? Turnos { get; set; }
        DbSet<Consultorios>? Consultorios { get; set; }
        DbSet<Habitaciones>? Habitaciones { get; set; }
        DbSet<Historiales>? Historiales { get; set; }
        DbSet<Solicitudes>? Solicitudes { get; set; }
        DbSet<Seguros>? Seguros { get; set; }
        DbSet<Citas>? Citas { get; set; }
        DbSet<Consultas>? Consultas { get; set; }
        DbSet<Enfermedades>? Enfermedades { get; set; }
        DbSet<Formulas>? Formulas { get; set; }
        DbSet<Examenes>? Examenes { get; set; }
        DbSet<Procedimientos>? Procedimientos { get; set; }
        DbSet<Medicamentos>? Medicamentos { get; set; }
        DbSet<Administrativos>? Administrativos { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<Pagos>? Pagos { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}