using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_lib.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Datosgenerales.ObtenerStringConexion()!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Hospitales>? Hospitales { get; set; }
        public DbSet<Pacientes>? Pacientes { get; set; }
        public DbSet<Sectores>? Sectores { get; set; }
        public DbSet<Medicos>? Medicos { get; set; }
        public DbSet<Turnos>? Turnos { get; set; }
        public DbSet<Consultorios>? Consultorios { get; set; }
        public DbSet<Habitaciones>? Habitaciones { get; set; }
        public DbSet<Historiales>? Historiales { get; set; }
        public DbSet<Solicitudes>? Solicitudes { get; set; }
        public DbSet<Seguros>? Seguros { get; set; }
        public DbSet<Citas>? Citas { get; set; }
        public DbSet<Consultas>? Consultas { get; set; }
        public DbSet<Enfermedades>? Enfermedades { get; set; }
        public DbSet<Formulas>? Formulas { get; set; }
        public DbSet<Examenes>? Examenes { get; set; }
        public DbSet<Procedimientos>? Procedimientos { get; set; }
        public DbSet<Medicamentos>? Medicamentos { get; set; }
        public DbSet<Administrativos>? Administrativos { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Permisos>? Permisos { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
    }
}