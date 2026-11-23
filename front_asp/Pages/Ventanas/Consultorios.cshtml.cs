using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using front_asp.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class ConsultoriosModel : PageModel
    {
        private ISectoresPresentacion ISectoresPresentacion;
        private IMedicosPresentacion IMedicosPresentacion;
        private IConsultoriosPresentacion IConsultoriosPresentacion;

        public ConsultoriosModel(ISectoresPresentacion ISectoresPresentacion,
            IMedicosPresentacion IMedicosPresentacion,
            IConsultoriosPresentacion IConsultoriosPresentacion)
        {
            this.ISectoresPresentacion = ISectoresPresentacion;
            this.IMedicosPresentacion = IMedicosPresentacion;
            this.IConsultoriosPresentacion = IConsultoriosPresentacion;
            this.Filtro = new Consultorios();
        }

        [BindProperty] public List<Sectores> Sectores { get; set; } = new List<Sectores>();
        [BindProperty] public List<Medicos> Medicos { get; set; } = new List<Medicos>();
        [BindProperty] public List<Consultorios> Lista { get; set; }
        [BindProperty] public Consultorios? Filtro { get; set; }
        [BindProperty] public Consultorios? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                // Solo entra si inicio sesion y su rol tiene permiso para esta ventana
                if (!Seguridad.TienePermiso(HttpContext, "Consultorios"))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Estado = Filtro!.Estado ?? "";
                Lista = this.IConsultoriosPresentacion.Buscar(Filtro!);
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
                this.Medicos = this.IMedicosPresentacion.Consultar();
                this.Actual = new Consultorios();
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
                    this.Actual = this.IConsultoriosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IConsultoriosPresentacion.Actualizar(this.Actual!);
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
                this.Medicos = this.IMedicosPresentacion.Consultar();
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
                this.Actual = this.IConsultoriosPresentacion.Borrar(this.Actual!);
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
