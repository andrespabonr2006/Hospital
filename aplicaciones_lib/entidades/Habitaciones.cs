using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Habitaciones
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public bool Disponibilidad { get; set; }
        public int Sector { get; set; }
        public int Paciente { get; set; }

        [ForeignKey("Sector")] public Sectores? _Sector { get; set; }
        [ForeignKey("Paciente")] public Pacientes? _Paciente { get; set; }
    }
}