using System.ComponentModel.DataAnnotations;

namespace ProyectoCurso.Dtos
{
    public class LibroCreacionDTO
    {
        [StringLength(maximumLength:250)]
        public string Titulo { get; set; }
    }
}
