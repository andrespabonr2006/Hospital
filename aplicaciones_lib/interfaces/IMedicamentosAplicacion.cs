using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IMedicamentosAplicacion
    {
        Medicamentos Insertar(Medicamentos entidad);
        List<Medicamentos> Consultar();
        Medicamentos Actualizar(Medicamentos entidad);
        Medicamentos Borrar(Medicamentos entidad);
    }
}
