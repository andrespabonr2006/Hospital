using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Citas
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Estado { get; set; }
        public int Solicitud { get; set; }
        public int Paciente { get; set; }

        [ForeignKey("Solicitud")] public Solicitudes? _Solicitud { get; set; }
        [ForeignKey("Paciente")] public Pacientes? _Paciente { get; set; }
    }
}