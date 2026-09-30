using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IPacientesAplicacion
    {
        Pacientes Insertar(Pacientes entidad);
        List<Pacientes> Consultar();
        Pacientes Actualizar(Pacientes entidad);
        Pacientes Borrar(Pacientes entidad);
    }
}
