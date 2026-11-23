using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using front_asp.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class FacturasModel : PageModel
    {
        private IMedicamentosPresentacion IMedicamentosPresentacion;
        private IProcedimientosPresentacion IProcedimientosPresentacion;
        private IAdministrativosPresentacion IAdministrativosPresentacion;
        private IFacturasPresentacion IFacturasPresentacion;

        public FacturasModel(IMedicamentosPresentacion IMedicamentosPresentacion,
            IProcedimientosPresentacion IProcedimientosPresentacion,
            IAdministrativosPresentacion IAdministrativosPresentacion,
            IFacturasPresentacion IFacturasPresentacion)
        {
            this.IMedicamentosPresentacion = IMedicamentosPresentacion;
            this.IProcedimientosPresentacion = IProcedimientosPresentacion;
            this.IAdministrativosPresentacion = IAdministrativosPresentacion;
            this.IFacturasPresentacion = IFacturasPresentacion;
            this.Filtro = new Facturas();
        }

        [BindProperty] public List<Medicamentos> Medicamentos { get; set; } = new List<Medicamentos>();
        [BindProperty] public List<Procedimientos> Procedimientos { get; set; } = new List<Procedimientos>();
        [BindProperty] public List<Administrativos> Administrativos { get; set; } = new List<Administrativos>();
        [BindProperty] public List<Facturas> Lista { get; set; }
        [BindProperty] public Facturas? Filtro { get; set; }
        [BindProperty] public Facturas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                // Solo entra si inicio sesion y su rol tiene permiso para esta ventana
                if (!Seguridad.TienePermiso(HttpContext, "Facturas"))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Lista = this.IFacturasPresentacion.Buscar(Filtro!);
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
                this.Medicamentos = this.IMedicamentosPresentacion.Consultar();
                this.Procedimientos = this.IProcedimientosPresentacion.Consultar();
                this.Administrativos = this.IAdministrativosPresentacion.Consultar();
                this.Actual = new Facturas();
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
                    this.Actual = this.IFacturasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IFacturasPresentacion.Actualizar(this.Actual!);
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
                this.Medicamentos = this.IMedicamentosPresentacion.Consultar();
                this.Procedimientos = this.IProcedimientosPresentacion.Consultar();
                this.Administrativos = this.IAdministrativosPresentacion.Consultar();
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
                this.Actual = this.IFacturasPresentacion.Borrar(this.Actual!);
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
