using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Enfermedades
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public string? NivelContagio { get; set; }
        public int Consulta { get; set; }

        [ForeignKey("Consulta")] public Consultas? _Consulta { get; set; }
    }
}
