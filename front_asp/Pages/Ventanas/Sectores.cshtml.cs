using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using front_asp.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class SectoresModel : PageModel
    {
        private IHospitalesPresentacion IHospitalesPresentacion;
        private ISectoresPresentacion ISectoresPresentacion;

        public SectoresModel(IHospitalesPresentacion IHospitalesPresentacion,
            ISectoresPresentacion ISectoresPresentacion)
        {
            this.IHospitalesPresentacion = IHospitalesPresentacion;
            this.ISectoresPresentacion = ISectoresPresentacion;
            this.Filtro = new Sectores();
        }

        [BindProperty] public List<Hospitales> Hospitales { get; set; } = new List<Hospitales>();
        [BindProperty] public List<Sectores> Lista { get; set; }
        [BindProperty] public Sectores? Filtro { get; set; }
        [BindProperty] public Sectores? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        
        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                // Solo entra si inicio sesion y su rol tiene permiso para esta ventana
                if (!Seguridad.TienePermiso(HttpContext, "Sectores"))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Nombre = Filtro!.Nombre ?? "";
                Lista = this.ISectoresPresentacion.Buscar(Filtro!);
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
                this.Hospitales = this.IHospitalesPresentacion.Consultar();
                this.Actual = new Sectores();
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
                    this.Actual = this.ISectoresPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ISectoresPresentacion.Actualizar(this.Actual!);
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
                this.Hospitales = this.IHospitalesPresentacion.Consultar();
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
                this.Actual = this.ISectoresPresentacion.Borrar(this.Actual!);
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
