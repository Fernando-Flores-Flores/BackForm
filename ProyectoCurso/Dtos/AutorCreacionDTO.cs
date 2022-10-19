using System.ComponentModel.DataAnnotations;

namespace ProyectoCurso.Dtos
{
    public class AutorCreacionDTO
    {
        [Required(ErrorMessage = "EL campo nombre es requerido :-(")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
        public string Nombre { get; set; }
    }
}
