using System.ComponentModel.DataAnnotations.Schema;

namespace aplicaciones_lib.entidades
{
    public class Pagos
    {
        public int Id { get; set; }
        public string? Metodo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int Factura { get; set; }

        [ForeignKey("Factura")] public Facturas? _Factura { get; set; }
    }
}