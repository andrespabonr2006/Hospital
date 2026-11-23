using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using front_asp.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class SolicitudesModel : PageModel
    {
        private IPacientesPresentacion IPacientesPresentacion;
        private ISolicitudesPresentacion ISolicitudesPresentacion;

        public SolicitudesModel(IPacientesPresentacion IPacientesPresentacion,
            ISolicitudesPresentacion ISolicitudesPresentacion)
        {
            this.IPacientesPresentacion = IPacientesPresentacion;
            this.ISolicitudesPresentacion = ISolicitudesPresentacion;
            this.Filtro = new Solicitudes();
        }

        [BindProperty] public List<Pacientes> Pacientes { get; set; } = new List<Pacientes>();
        [BindProperty] public List<Solicitudes> Lista { get; set; }
        [BindProperty] public Solicitudes? Filtro { get; set; }
        [BindProperty] public Solicitudes? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                // Solo entra si inicio sesion y su rol tiene permiso para esta ventana
                if (!Seguridad.TienePermiso(HttpContext, "Solicitudes"))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Motivo = Filtro!.Motivo ?? "";
                Lista = this.ISolicitudesPresentacion.Buscar(Filtro!);
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
                this.Pacientes = this.IPacientesPresentacion.Consultar();
                this.Actual = new Solicitudes();
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
                    this.Actual = this.ISolicitudesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ISolicitudesPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.ISolicitudesPresentacion.Borrar(this.Actual!);
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
