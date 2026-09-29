using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Solicitudes
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? NivelUrgencia { get; set; }
        public string? Motivo { get; set; }
        public int Paciente { get; set; }

        [ForeignKey("Paciente")] public Pacientes? _Paciente { get; set; }
    }
}