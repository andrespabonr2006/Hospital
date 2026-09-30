using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IFormulasAplicacion
    {
        Formulas Insertar(Formulas entidad);
        List<Formulas> Consultar();
        Formulas Actualizar(Formulas entidad);
        Formulas Borrar(Formulas entidad);
    }
}
