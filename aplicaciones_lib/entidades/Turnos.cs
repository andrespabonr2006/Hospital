using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Turnos
    {
        public int Id { get; set; }
        public string? Jornada { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public int Medico { get; set; }

        [ForeignKey("Medico")] public Medicos? _Medico { get; set; }
    }
}
