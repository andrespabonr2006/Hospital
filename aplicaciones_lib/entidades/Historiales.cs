using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Historiales
    {
        public int Id { get; set; }
        public DateTime? FechaApertura { get; set; }
        public string? Antecedente { get; set; }
        public int Paciente { get; set; }

        [ForeignKey("Paciente")] public Pacientes? _Paciente { get; set; }
    }
}
