using System.ComponentModel.DataAnnotations;

namespace ProyectoCurso.Dtos.DtoResponse
{
    public class PersonaResponseDto
    {
        public int id { get; set; }

        public int nroCarnet { get; set; }
        public string extension { get; set; }
    }
}
