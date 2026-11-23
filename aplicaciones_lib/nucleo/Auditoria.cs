using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;

namespace aplicaciones_lib.nucleo
{
    public class Auditoria
    {
       
        public static void Registrar(IConexion conexion,
            string entidad,
            string operacion,
            int registro)
        {
            var auditoria = new Auditorias()
            {
                Entidad = entidad,
                Operacion = operacion,
                Registro = registro,
                Fecha = DateTime.Now
            };
            conexion.Auditorias!.Add(auditoria);
            conexion.SaveChanges();
        }
    }
}
