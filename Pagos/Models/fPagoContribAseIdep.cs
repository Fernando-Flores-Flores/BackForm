using System.ComponentModel.DataAnnotations;

namespace Pagos.Models
{
    public class fPagoContribAseIdep
    {
        [Key]
        public int Id { get; set; }

        public string? tipoAsegurado { get; set; }
        public string? tipoIdentificacion { get; set; }

        public int nroIdentificacion { get; set; }

        public string? complemento { get; set; }

        public int nuaCua { get; set; }

        public string? periodoCotizacion { get; set; }

        public string? fechaPago { get; set; }

        public string? perfilEdad { get; set; }

        public string? primerApellido { get; set; }

        public string? segundoApellido { get; set; }

        public string? apellidoCasada { get; set; }

        public string? primerNombre { get; set; }

        public string? segundoNombre { get; set; }

        public string? departamento { get; set; }

        public string? provincia { get; set; }

        public string? ciudad { get; set; }

        public string? Zona { get; set; }

        public string? direccion { get; set; }

        public int nroVivienda { get; set; }

        public string? email { get; set; }

        public int telCel { get; set; }

        public string? lugarPago { get; set; }

        public int nroAportesPagar { get; set; }

        public string? formaPago { get; set; }
    }
}
