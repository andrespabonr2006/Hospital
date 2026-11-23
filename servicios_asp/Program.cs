using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opciones =>
{
    opciones.JsonSerializerOptions.Encoder =
        System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
});
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IHospitalesAplicacion, HospitalesAplicacion>();
builder.Services.AddScoped<IPacientesAplicacion, PacientesAplicacion>();
builder.Services.AddScoped<ISectoresAplicacion, SectoresAplicacion>();
builder.Services.AddScoped<IMedicosAplicacion, MedicosAplicacion>();
builder.Services.AddScoped<ITurnosAplicacion, TurnosAplicacion>();
builder.Services.AddScoped<IConsultoriosAplicacion, ConsultoriosAplicacion>();
builder.Services.AddScoped<IHabitacionesAplicacion, HabitacionesAplicacion>();
builder.Services.AddScoped<IHistorialesAplicacion, HistorialesAplicacion>();
builder.Services.AddScoped<ISolicitudesAplicacion, SolicitudesAplicacion>();
builder.Services.AddScoped<ISegurosAplicacion, SegurosAplicacion>();
builder.Services.AddScoped<ICitasAplicacion, CitasAplicacion>();
builder.Services.AddScoped<IConsultasAplicacion, ConsultasAplicacion>();
builder.Services.AddScoped<IEnfermedadesAplicacion, EnfermedadesAplicacion>();
builder.Services.AddScoped<IFormulasAplicacion, FormulasAplicacion>();
builder.Services.AddScoped<IExamenesAplicacion, ExamenesAplicacion>();
builder.Services.AddScoped<IProcedimientosAplicacion, ProcedimientosAplicacion>();
builder.Services.AddScoped<IMedicamentosAplicacion, MedicamentosAplicacion>();
builder.Services.AddScoped<IAdministrativosAplicacion, AdministrativosAplicacion>();
builder.Services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
builder.Services.AddScoped<IPagosAplicacion, PagosAplicacion>();
builder.Services.AddScoped<IRolesAplicacion, RolesAplicacion>();
builder.Services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
builder.Services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
builder.Services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();
