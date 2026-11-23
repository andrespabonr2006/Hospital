using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using front_asp.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class HabitacionesModel : PageModel
    {
        private ISectoresPresentacion ISectoresPresentacion;
        private IPacientesPresentacion IPacientesPresentacion;
        private IHabitacionesPresentacion IHabitacionesPresentacion;

        public HabitacionesModel(ISectoresPresentacion ISectoresPresentacion,
            IPacientesPresentacion IPacientesPresentacion,
            IHabitacionesPresentacion IHabitacionesPresentacion)
        {
            this.ISectoresPresentacion = ISectoresPresentacion;
            this.IPacientesPresentacion = IPacientesPresentacion;
            this.IHabitacionesPresentacion = IHabitacionesPresentacion;
            this.Filtro = new Habitaciones();
        }

        [BindProperty] public List<Sectores> Sectores { get; set; } = new List<Sectores>();
        [BindProperty] public List<Pacientes> Pacientes { get; set; } = new List<Pacientes>();
        [BindProperty] public List<Habitaciones> Lista { get; set; }
        [BindProperty] public Habitaciones? Filtro { get; set; }
        [BindProperty] public Habitaciones? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                // Solo entra si inicio sesion y su rol tiene permiso para esta ventana
                if (!Seguridad.TienePermiso(HttpContext, "Habitaciones"))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Tipo = Filtro!.Tipo ?? "";
                Lista = this.IHabitacionesPresentacion.Buscar(Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Sectores = this.ISectoresPresentacion.Consultar();
                this.Pacientes = this.IPacientesPresentacion.Consultar();
                this.Actual = new Habitaciones();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.IHabitacionesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IHabitacionesPresentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                this.Sectores = this.ISectoresPresentacion.Consultar();
                this.Pacientes = this.IPacientesPresentacion.Consultar();
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.IHabitacionesPresentacion.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}
