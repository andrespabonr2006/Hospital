using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IExamenesAplicacion
    {
        Examenes Insertar(Examenes entidad);
        List<Examenes> Consultar();
        Examenes Actualizar(Examenes entidad);
        Examenes Borrar(Examenes entidad);
    }
}
