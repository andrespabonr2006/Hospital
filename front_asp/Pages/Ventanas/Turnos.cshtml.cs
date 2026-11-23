using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages.Ventanas
{
    public class TurnosModel : PageModel
    {
        private IMedicosPresentacion IMedicosPresentacion;
        private ITurnosPresentacion ITurnosPresentacion;

        public TurnosModel(IMedicosPresentacion IMedicosPresentacion,
            ITurnosPresentacion ITurnosPresentacion)
        {
            this.IMedicosPresentacion = IMedicosPresentacion;
            this.ITurnosPresentacion = ITurnosPresentacion;
            this.Filtro = new Turnos();
        }

        [BindProperty] public List<Medicos> Medicos { get; set; } = new List<Medicos>();
        [BindProperty] public List<Turnos> Lista { get; set; }
        [BindProperty] public Turnos? Filtro { get; set; }
        [BindProperty] public Turnos? Actual { get; set; }
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

                Filtro!.Jornada = Filtro!.Jornada ?? "";
                Lista = this.ITurnosPresentacion.Buscar(Filtro!);
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
                this.Medicos = this.IMedicosPresentacion.Consultar();
                this.Actual = new Turnos();
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
                    this.Actual = this.ITurnosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ITurnosPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.ITurnosPresentacion.Borrar(this.Actual!);
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
