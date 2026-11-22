using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Examenes
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public string? Resultado { get; set; }
        public DateTime? Fecha { get; set; }
        public int Formula { get; set; }

        [ForeignKey("Formula")] public Formulas? _Formula { get; set; }
    }
}