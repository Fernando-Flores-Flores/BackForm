using System.ComponentModel.DataAnnotations;

namespace ProyectoCurso.Dtos
{
    public class PersonaCreacionDto
    {
      
        [Required(ErrorMessage = "EL campo nombre es requerido :-(")]

        public int nroCarnet { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe de tener más de {1} caracteres")]
        public string extension { get; set; }

    }
}
