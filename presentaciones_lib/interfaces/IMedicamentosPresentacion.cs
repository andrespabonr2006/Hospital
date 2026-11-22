using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IMedicamentosPresentacion
    {
        Medicamentos Insertar(Medicamentos entidad);
        Medicamentos Actualizar(Medicamentos entidad);
        List<Medicamentos> Consultar();
        List<Medicamentos> Buscar(Medicamentos entidad);
        Medicamentos Borrar(Medicamentos entidad);
    }
}