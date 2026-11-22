using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IExamenesAplicacion
    {
        Examenes Insertar(Examenes entidad);
        Examenes Actualizar(Examenes entidad);
        List<Examenes> Consultar();
        List<Examenes> Buscar(Examenes entidad);
        Examenes Borrar(Examenes entidad);
    }
}

