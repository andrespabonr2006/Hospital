using aplicaciones_lib.entidades;
using aplicaciones_lib.interfaces;
using aplicaciones_lib.nucleo;
using ClosedXML.Excel;
using front_asp.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_asp.Pages
{
    public class ReportesModel : PageModel
    {
        private IPacientesPresentacion IPacientesPresentacion;

        public ReportesModel(IPacientesPresentacion IPacientesPresentacion)
        {
            this.IPacientesPresentacion = IPacientesPresentacion;
        }

        public IActionResult OnGet()
        {
            if (!Seguridad.TienePermiso(HttpContext, "Reportes"))
                return Redirect("/");
            return Page();
        }

        // Genera un archivo Excel (.xlsx) con la lista de pacientes
        public IActionResult OnPostExcel()
        {
            try
            {
                var lista = this.IPacientesPresentacion.Buscar(new Pacientes() { Nombre = "" });

                using var libro = new XLWorkbook();
                var hoja = libro.Worksheets.Add("Pacientes");

                // Fila 1: los titulos de las columnas
                hoja.Cell(1, 1).Value = "Id";
                hoja.Cell(1, 2).Value = "Nombre";
                hoja.Cell(1, 3).Value = "Telefono";
                hoja.Cell(1, 4).Value = "Direccion";

                // Desde la fila 2: un paciente por fila
                int fila = 2;
                foreach (var x in lista)
                {
                    hoja.Cell(fila, 1).Value = x.Id;
                    hoja.Cell(fila, 2).Value = x.Nombre ?? "";
                    hoja.Cell(fila, 3).Value = x.Telefono ?? "";
                    hoja.Cell(fila, 4).Value = x.Direccion ?? "";
                    fila++;
                }

                using var memoria = new MemoryStream();
                libro.SaveAs(memoria);
                return File(memoria.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "Pacientes.xlsx");
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return Page();
            }
        }
    }
}
