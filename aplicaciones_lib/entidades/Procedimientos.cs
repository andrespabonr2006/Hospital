using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Procedimientos
    {
        public int Id { get; set; }
        public string? Proceso { get; set; }
        public string? Duracion { get; set; }
        public decimal Costo { get; set; }
        public int Examen { get; set; }

        [ForeignKey("Examen")] public Examenes? _Examen { get; set; }

        [NotMapped] public List<Facturas>? Facturas { get; set; }
    }
}