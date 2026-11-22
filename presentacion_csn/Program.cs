using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using Microsoft.EntityFrameworkCore;

try
{
    IConexion conexion = new Conexion();
    var lista = conexion.Hospitales!.ToList();
    Console.WriteLine("Hospitales en la base de datos: " + lista.Count);
    Console.WriteLine("Pacientes en la base de datos: " + conexion.Pacientes!.Count());
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("presentacion_csn");

