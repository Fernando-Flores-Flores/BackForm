using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCurso.Controllers.Entidades;

namespace ProyectoCurso.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibrosControler : ControllerBase
    {
        public readonly ApplicationDbContext costext;
        public LibrosControler(ApplicationDbContext context)
        {
            this.costext = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id) 
        {
            return await costext.Libros.Include(x=>x.Autor).FirstOrDefaultAsync(x => x.id == id);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existeAutor = await costext.Autores.AnyAsync(x => x.id == libro.AutorId);
            if (!existeAutor)
            {
                return BadRequest($"No existe el autor de Id:{libro.AutorId}");
            }
            costext.Add(libro);
            await costext.SaveChangesAsync();
            return Ok();

        }
        
    }
}
