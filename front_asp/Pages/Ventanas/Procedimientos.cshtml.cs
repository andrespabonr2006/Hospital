using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class ProcedimientosModel : PageModel
    {
        private IExamenesPresentacion IExamenesPresentacion;
        private IProcedimientosPresentacion IProcedimientosPresentacion;

        public ProcedimientosModel(IExamenesPresentacion IExamenesPresentacion,
            IProcedimientosPresentacion IProcedimientosPresentacion)
        {
            this.IExamenesPresentacion = IExamenesPresentacion;
            this.IProcedimientosPresentacion = IProcedimientosPresentacion;
            this.Filtro = new Procedimientos();
        }

        [BindProperty] public List<Examenes> Examenes { get; set; } = new List<Examenes>();
        [BindProperty] public List<Procedimientos> Lista { get; set; }
        [BindProperty] public Procedimientos? Filtro { get; set; }
        [BindProperty] public Procedimientos? Actual { get; set; }
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

                Filtro!.Proceso = Filtro!.Proceso ?? "";
                Lista = this.IProcedimientosPresentacion.Buscar(Filtro!);
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
                this.Examenes = this.IExamenesPresentacion.Consultar();
                this.Actual = new Procedimientos();
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
                    this.Actual = this.IProcedimientosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IProcedimientosPresentacion.Actualizar(this.Actual!);
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
                this.Examenes = this.IExamenesPresentacion.Consultar();
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
                this.Actual = this.IProcedimientosPresentacion.Borrar(this.Actual!);
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
