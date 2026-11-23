using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages
{
    public class IndexModel : PageModel
    {
        private IUsuariosPresentacion IUsuariosPresentacion;
        private IPermisosPresentacion IPermisosPresentacion;

        public IndexModel(IUsuariosPresentacion IUsuariosPresentacion,
            IPermisosPresentacion IPermisosPresentacion)
        {
            this.IUsuariosPresentacion = IUsuariosPresentacion;
            this.IPermisosPresentacion = IPermisosPresentacion;
        }

        public bool EstaLogueado = false;
        public string? NombreUsuario;
        public string? NombreRol;
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contrasena { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                NombreUsuario = variable_session;
                NombreRol = HttpContext.Session.GetString("Rol");
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) ||
                    string.IsNullOrEmpty(Contrasena))
                {
                    ViewData["Error"] = "Escriba el usuario y la contraseña";
                    return;
                }

                // 1. Se le pregunta a la API si el usuario y la contrasena son correctos
                var usuario = this.IUsuariosPresentacion.Login(new Usuarios()
                {
                    Correo = Email,
                    Contrasena = Contrasena
                });

                if (usuario == null)
                {
                    ViewData["Error"] = "Usuario o contraseña incorrectos";
                    OnPostBtClean();
                    return;
                }

                // 2. Se buscan las ventanas que puede abrir su rol
                var permisos = this.IPermisosPresentacion
                    .Buscar(new Permisos() { Ventana = "" })
                    .Where(x => x.Rol == usuario.Rol)
                    .Select(x => x.Ventana)
                    .ToList();

                // 3. Se guarda todo en la sesion
                HttpContext.Session.SetString("Usuario", usuario.Nombre!);
                HttpContext.Session.SetString("Rol", usuario._Rol!.Nombre!);
                HttpContext.Session.SetString("Permisos", string.Join(",", permisos));

                EstaLogueado = true;
                NombreUsuario = usuario.Nombre;
                NombreRol = usuario._Rol!.Nombre;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
