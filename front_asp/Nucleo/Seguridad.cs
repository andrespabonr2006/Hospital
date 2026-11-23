namespace front_asp.Nucleo
{
    public class Seguridad
    {
        // Dice si el usuario que inicio sesion puede abrir una ventana.
        // - Sin sesion: no puede.
        // - Rol Administrador: puede todo.
        // - Otro rol: solo las ventanas que estan en sus Permisos.
        public static bool TienePermiso(HttpContext contexto, string ventana)
        {
            var usuario = contexto.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(usuario))
                return false;

            if (EsAdministrador(contexto))
                return true;

            var permisos = contexto.Session.GetString("Permisos") ?? "";
            return permisos.Split(',').Contains(ventana);
        }

        public static bool EsAdministrador(HttpContext contexto)
        {
            return contexto.Session.GetString("Rol") == "Administrador";
        }

        public static bool EstaLogueado(HttpContext contexto)
        {
            return !string.IsNullOrEmpty(contexto.Session.GetString("Usuario"));
        }
    }
}
