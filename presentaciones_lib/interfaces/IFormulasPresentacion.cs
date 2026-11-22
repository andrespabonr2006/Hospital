using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IFormulasPresentacion
    {
        Formulas Insertar(Formulas entidad);
        Formulas Actualizar(Formulas entidad);
        List<Formulas> Consultar();
        List<Formulas> Buscar(Formulas entidad);
        Formulas Borrar(Formulas entidad);
    }
}