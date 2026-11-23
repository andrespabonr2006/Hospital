using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using presentaciones_lib.implementaciones;
using presentaciones_lib.interfaces;

// QuestPDF (reportes PDF) es gratis para estudiantes con la licencia Community
QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllers();
builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<IHospitalesPresentacion, HospitalesPresentacion>();
builder.Services.AddScoped<IPacientesPresentacion, PacientesPresentacion>();
builder.Services.AddScoped<ISectoresPresentacion, SectoresPresentacion>();
builder.Services.AddScoped<IMedicosPresentacion, MedicosPresentacion>();
builder.Services.AddScoped<ITurnosPresentacion, TurnosPresentacion>();
builder.Services.AddScoped<IConsultoriosPresentacion, ConsultoriosPresentacion>();
builder.Services.AddScoped<IHabitacionesPresentacion, HabitacionesPresentacion>();
builder.Services.AddScoped<IHistorialesPresentacion, HistorialesPresentacion>();
builder.Services.AddScoped<ISolicitudesPresentacion, SolicitudesPresentacion>();
builder.Services.AddScoped<ISegurosPresentacion, SegurosPresentacion>();
builder.Services.AddScoped<ICitasPresentacion, CitasPresentacion>();
builder.Services.AddScoped<IConsultasPresentacion, ConsultasPresentacion>();
builder.Services.AddScoped<IEnfermedadesPresentacion, EnfermedadesPresentacion>();
builder.Services.AddScoped<IFormulasPresentacion, FormulasPresentacion>();
builder.Services.AddScoped<IExamenesPresentacion, ExamenesPresentacion>();
builder.Services.AddScoped<IProcedimientosPresentacion, ProcedimientosPresentacion>();
builder.Services.AddScoped<IMedicamentosPresentacion, MedicamentosPresentacion>();
builder.Services.AddScoped<IAdministrativosPresentacion, AdministrativosPresentacion>();
builder.Services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
builder.Services.AddScoped<IPagosPresentacion, PagosPresentacion>();
builder.Services.AddScoped<IRolesPresentacion, RolesPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
builder.Services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
builder.Services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();