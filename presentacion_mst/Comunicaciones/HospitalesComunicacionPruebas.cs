using aplicaciones_lib.entidades;
using aplicaciones_lib.implementaciones;
using aplicaciones_lib.interfaces;

namespace presentacion_mst.PruebasApi
{
    // Prueba el camino completo: Presentacion -> Comunicaciones -> API -> Base de datos.
    // La API (servicios_asp) debe estar encendida.
    [TestClass]
    public class HospitalesComunicacionPruebas
    {
        private IHospitalesPresentacion presentacion;
        private Hospitales? entidad = null;

        public HospitalesComunicacionPruebas()
        {
            this.presentacion = new HospitalesPresentacion(
                new presentaciones_lib.implementaciones.Comunicaciones());
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Buscar();
            Actualizar();
            Borrar();
        }

        private void Insertar()
        {
            this.entidad = this.presentacion.Insertar(new Hospitales()
            {
                Nombre = "Hospital API Prueba",
                Direccion = "Calle 50 # 40-20",
                Telefono = "6045550000",
                Correo = "api@hospital.com",
            });
            Assert.IsTrue(this.entidad.Id > 0);
        }

        private void Buscar()
        {
            var lista = this.presentacion.Buscar(new Hospitales() { Nombre = "" });
            Assert.IsTrue(lista.Any(x => x.Id == this.entidad!.Id));
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "6045551111";
            this.entidad = this.presentacion.Actualizar(this.entidad!);
            Assert.IsNotNull(this.entidad);
        }

        private void Borrar()
        {
            this.presentacion.Borrar(this.entidad!);
            var lista = this.presentacion.Buscar(new Hospitales() { Nombre = "" });
            Assert.IsFalse(lista.Any(x => x.Id == this.entidad!.Id));
        }
    }
}
