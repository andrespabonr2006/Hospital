using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Medicamentos
    {
        public int Id { get; set; }
        public string? NombreComercial { get; set; }
        public string? Dosis { get; set; }
        public int Disponibilidad { get; set; }

        [NotMapped] public List<Facturas>? Facturas { get; set; }
    }
}