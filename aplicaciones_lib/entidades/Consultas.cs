using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Consultas
    {
        public int Id { get; set; }
        public string? Observacion { get; set; }
        public string? SignosVitales { get; set; }
        public decimal CostoConsulta { get; set; }
        public int Cita { get; set; }

        [ForeignKey("Cita")] public Citas? _Cita { get; set; }
    }
}