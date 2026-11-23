using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        [NotMapped] public List<Usuarios>? Usuarios { get; set; }
        [NotMapped] public List<Permisos>? Permisos { get; set; }
    }
}
