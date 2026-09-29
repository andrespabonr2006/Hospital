using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public int Medicamento { get; set; }
        public int Procedimiento { get; set; }
        public int Administrativo { get; set; }

        [ForeignKey("Medicamento")] public Medicamentos? _Medicamento { get; set; }
        [ForeignKey("Procedimiento")] public Procedimientos? _Procedimiento { get; set; }
        [ForeignKey("Administrativo")] public Administrativos? _Administrativo { get; set; }
    }
}