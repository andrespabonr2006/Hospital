namespace aplicaciones_lib.entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? Entidad { get; set; }
        public string? Operacion { get; set; }
        public int Registro { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
