using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface ISegurosPresentacion
    {
        Seguros Insertar(Seguros entidad);
        Seguros Actualizar(Seguros entidad);
        List<Seguros> Consultar();
        List<Seguros> Buscar(Seguros entidad);
        Seguros Borrar(Seguros entidad);
    }
}