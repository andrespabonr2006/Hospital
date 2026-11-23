using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using front_asp.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    // Ventana de solo lectura: la auditoria no se crea, edita ni borra a mano.
    public class AuditoriasModel : PageModel
    {
        private IAuditoriasPresentacion IAuditoriasPresentacion;

        public AuditoriasModel(IAuditoriasPresentacion IAuditoriasPresentacion)
        {
            this.IAuditoriasPresentacion = IAuditoriasPresentacion;
            this.Filtro = new Auditorias();
        }

        [BindProperty] public List<Auditorias> Lista { get; set; } = new List<Auditorias>();
        [BindProperty] public Auditorias? Filtro { get; set; }

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
               
                if (!Seguridad.EsAdministrador(HttpContext))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Entidad = Filtro!.Entidad ?? "";
                Lista = this.IAuditoriasPresentacion.Buscar(Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
