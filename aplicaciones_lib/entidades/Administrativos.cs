using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Administrativos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }
        public string? Telefono { get; set; }
        public int Hospital { get; set; }

        [ForeignKey("Hospital")] public Hospitales? _Hospital { get; set; }

        [NotMapped] public List<Facturas>? Facturas { get; set; }
    }
}
