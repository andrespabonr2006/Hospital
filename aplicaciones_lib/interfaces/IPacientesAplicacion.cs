using aplicaciones_lib.entidades;

namespace aplicaciones_lib.interfaces
{
    public interface IPacientesAplicacion
    {
        Pacientes Insertar(Pacientes entidad);
        Pacientes Actualizar(Pacientes entidad);
        List<Pacientes> Consultar();
        List<Pacientes> Buscar(Pacientes entidad);
        Pacientes Borrar(Pacientes entidad);
    }
}

