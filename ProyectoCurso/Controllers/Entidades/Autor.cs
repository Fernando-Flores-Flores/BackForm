using ProyectoCurso.ValidacionesPersonalizadas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoCurso.Controllers.Entidades
{
    public class Autor
    {
        public int id { get; set; }

       // [PrimeraLetraMayuscula]
        [Required(ErrorMessage ="EL campo nombre es requerido :-(")]
        [StringLength(maximumLength:20,ErrorMessage ="El campo {0} no debe de tener más de {1} caracteres")]
        public string Nombre { get; set; }

        [Range(18,120)]
        [NotMapped]//El NotMapped dice que no es un campo o columna en la tabla correcpondiente
        public int Edad { get; set; }
        public List<Libro> Libros { get; set; }

    }
}
