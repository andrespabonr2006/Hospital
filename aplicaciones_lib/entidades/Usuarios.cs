using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public bool Activo { get; set; }
        public int Rol { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
    }
}
