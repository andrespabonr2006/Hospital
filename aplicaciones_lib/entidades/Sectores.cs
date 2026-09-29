using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Sectores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Piso { get; set; }
        public string? Descripcion { get; set; }
        public int Hospital { get; set; }

        [ForeignKey("Hospital")] public Hospitales? _Hospital { get; set; }
    }
}