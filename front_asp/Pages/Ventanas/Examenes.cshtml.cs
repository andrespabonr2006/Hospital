using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using front_asp.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class ExamenesModel : PageModel
    {
        private IFormulasPresentacion IFormulasPresentacion;
        private IExamenesPresentacion IExamenesPresentacion;

        public ExamenesModel(IFormulasPresentacion IFormulasPresentacion,
            IExamenesPresentacion IExamenesPresentacion)
        {
            this.IFormulasPresentacion = IFormulasPresentacion;
            this.IExamenesPresentacion = IExamenesPresentacion;
            this.Filtro = new Examenes();
        }

        [BindProperty] public List<Formulas> Formulas { get; set; } = new List<Formulas>();
        [BindProperty] public List<Examenes> Lista { get; set; }
        [BindProperty] public Examenes? Filtro { get; set; }
        [BindProperty] public Examenes? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        
        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                // Solo entra si inicio sesion y su rol tiene permiso para esta ventana
                if (!Seguridad.TienePermiso(HttpContext, "Examenes"))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Tipo = Filtro!.Tipo ?? "";
                Lista = this.IExamenesPresentacion.Buscar(Filtro!);
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
                this.Formulas = this.IFormulasPresentacion.Consultar();
                this.Actual = new Examenes();
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
                    this.Actual = this.IExamenesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IExamenesPresentacion.Actualizar(this.Actual!);
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
                this.Formulas = this.IFormulasPresentacion.Consultar();
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
                this.Actual = this.IExamenesPresentacion.Borrar(this.Actual!);
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
