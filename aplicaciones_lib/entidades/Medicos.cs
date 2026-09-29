using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Medicos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public string? Telefono { get; set; }
        public int Sector { get; set; }

        [ForeignKey("Sector")] public Sectores? _Sector { get; set; }
    }
}