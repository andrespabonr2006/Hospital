using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class ConsultasModel : PageModel
    {
        private ICitasPresentacion ICitasPresentacion;
        private IConsultasPresentacion IConsultasPresentacion;

        public ConsultasModel(ICitasPresentacion ICitasPresentacion,
            IConsultasPresentacion IConsultasPresentacion)
        {
            this.ICitasPresentacion = ICitasPresentacion;
            this.IConsultasPresentacion = IConsultasPresentacion;
            this.Filtro = new Consultas();
        }

        [BindProperty] public List<Citas> Citas { get; set; } = new List<Citas>();
        [BindProperty] public List<Consultas> Lista { get; set; }
        [BindProperty] public Consultas? Filtro { get; set; }
        [BindProperty] public Consultas? Actual { get; set; }
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

                Filtro!.Observacion = Filtro!.Observacion ?? "";
                Lista = this.IConsultasPresentacion.Buscar(Filtro!);
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
                this.Citas = this.ICitasPresentacion.Consultar();
                this.Actual = new Consultas();
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
                    this.Actual = this.IConsultasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IConsultasPresentacion.Actualizar(this.Actual!);
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
                this.Citas = this.ICitasPresentacion.Consultar();
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
                this.Actual = this.IConsultasPresentacion.Borrar(this.Actual!);
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
