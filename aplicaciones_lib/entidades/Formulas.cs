using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Formulas
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Indicacion { get; set; }
        public string? Vigencia { get; set; }
        public int Consulta { get; set; }

        [ForeignKey("Consulta")] public Consultas? _Consulta { get; set; }
    }
}