using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class CitasModel : PageModel
    {
        private ISolicitudesPresentacion ISolicitudesPresentacion;
        private IPacientesPresentacion IPacientesPresentacion;
        private ICitasPresentacion ICitasPresentacion;

        public CitasModel(ISolicitudesPresentacion ISolicitudesPresentacion,
            IPacientesPresentacion IPacientesPresentacion,
            ICitasPresentacion ICitasPresentacion)
        {
            this.ISolicitudesPresentacion = ISolicitudesPresentacion;
            this.IPacientesPresentacion = IPacientesPresentacion;
            this.ICitasPresentacion = ICitasPresentacion;
            this.Filtro = new Citas();
        }

        [BindProperty] public List<Solicitudes> Solicitudes { get; set; } = new List<Solicitudes>();
        [BindProperty] public List<Pacientes> Pacientes { get; set; } = new List<Pacientes>();
        [BindProperty] public List<Citas> Lista { get; set; }
        [BindProperty] public Citas? Filtro { get; set; }
        [BindProperty] public Citas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Estado = Filtro!.Estado ?? "";
                Lista = this.ICitasPresentacion.Buscar(Filtro!);
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
                this.Solicitudes = this.ISolicitudesPresentacion.Consultar();
                this.Pacientes = this.IPacientesPresentacion.Consultar();
                this.Actual = new Citas();
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
                    this.Actual = this.ICitasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICitasPresentacion.Actualizar(this.Actual!);
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
                this.Solicitudes = this.ISolicitudesPresentacion.Consultar();
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
                this.Actual = this.ICitasPresentacion.Borrar(this.Actual!);
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

