using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Consultorios
    {
        public int Id { get; set; }
        public string? Estado { get; set; }
        public string? Equipamiento { get; set; }
        public int Sector { get; set; }
        public int Medico { get; set; }

        [ForeignKey("Sector")] public Sectores? _Sector { get; set; }
        [ForeignKey("Medico")] public Medicos? _Medico { get; set; }
    }
}