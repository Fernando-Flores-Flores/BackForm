using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCurso.Controllers.Entidades;
using ProyectoCurso.Dtos;
using ProyectoCurso.Dtos.DtoResponse;

namespace ProyectoCurso.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibrosControler : ControllerBase
    {
        public readonly ApplicationDbContext costext;
        private readonly IMapper mapper;

        public LibrosControler(ApplicationDbContext context,IMapper mapper)
        {
            this.costext = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LibroResponseDTO>> Get(int id)
        {
            var libro= await costext.Libros.FirstOrDefaultAsync(x => x.id == id);
            return mapper.Map<LibroResponseDTO>(libro);
        }

        [HttpPost]
        public async Task<ActionResult> Post(LibroCreacionDTO libroCreacionDto)
        {
            //var existeAutor = await costext.Autores.AnyAsync(x => x.id == libro.AutorId);
            //if (!existeAutor)
            //{
            //    return BadRequest($"No existe el autor de Id:{libro.AutorId}");
            //}
            var libro = this.mapper.Map<Libro>(libroCreacionDto);   
            costext.Add(libro);
            await costext.SaveChangesAsync();
            return Ok();
        }

    }
}
