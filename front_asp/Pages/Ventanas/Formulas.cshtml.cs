using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class FormulasModel : PageModel
    {
        private IConsultasPresentacion IConsultasPresentacion;
        private IFormulasPresentacion IFormulasPresentacion;

        public FormulasModel(IConsultasPresentacion IConsultasPresentacion,
            IFormulasPresentacion IFormulasPresentacion)
        {
            this.IConsultasPresentacion = IConsultasPresentacion;
            this.IFormulasPresentacion = IFormulasPresentacion;
            this.Filtro = new Formulas();
        }

        [BindProperty] public List<Consultas> Consultas { get; set; } = new List<Consultas>();
        [BindProperty] public List<Formulas> Lista { get; set; }
        [BindProperty] public Formulas? Filtro { get; set; }
        [BindProperty] public Formulas? Actual { get; set; }
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

                Filtro!.Indicacion = Filtro!.Indicacion ?? "";
                Lista = this.IFormulasPresentacion.Buscar(Filtro!);
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
                this.Consultas = this.IConsultasPresentacion.Consultar();
                this.Actual = new Formulas();
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
                    this.Actual = this.IFormulasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IFormulasPresentacion.Actualizar(this.Actual!);
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
                this.Consultas = this.IConsultasPresentacion.Consultar();
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
                this.Actual = this.IFormulasPresentacion.Borrar(this.Actual!);
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
