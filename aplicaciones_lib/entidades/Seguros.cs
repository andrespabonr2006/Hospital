using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Seguros
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string? Cobertura { get; set; }
        public int Solicitud { get; set; }

        [ForeignKey("Solicitud")] public Solicitudes? _Solicitud { get; set; }
    }
}