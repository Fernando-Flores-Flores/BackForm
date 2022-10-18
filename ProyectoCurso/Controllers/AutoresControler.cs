using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCurso.Controllers.Entidades;
using ProyectoCurso.Servicios;

namespace ProyectoCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresControler : ControllerBase
    {
        public readonly ApplicationDbContext constext;
        private readonly IServicio servicio;

        public AutoresControler(ApplicationDbContext context ,IServicio servicio)
        {
            this.constext = context;
            this.servicio = servicio;
        }

        [HttpGet]//Api/autores
        [HttpGet("listado")]//Api/autores/listado
        [HttpGet("/listado")]//listado
        public async Task<ActionResult<List<Autor>>> GetAutores()
        {
            return await constext.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<ActionResult<Autor>> PrimerAutor([FromHeader] int miValor, [FromQuery] string nombre)
        {
            return await constext.Autores.FirstOrDefaultAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Autor autor) {
            var existeAUtorConMismoNombre = await constext.Autores.AnyAsync(x=>x.Nombre == autor.Nombre);
            if (existeAUtorConMismoNombre)
            {

                return BadRequest($"Ya existe un autor co el mismo nombre{autor.Nombre}");
            }
            
            
            constext.Add(autor);
            await constext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //api/autores/1
        public async Task<ActionResult> Put(Autor autor,int id)
        {
            if (autor.id != id) {
                return BadRequest("El id del autor no coindice con el id de la URL");
            }
            var existe = await constext.Autores.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            constext.Update(autor);

            await constext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var existe = await constext.Autores.AnyAsync(x=>x.id ==id);
            if (!existe)
            {
                return NotFound();
            }
            constext.Remove(new Autor() { id = id });
            await constext.SaveChangesAsync();
            return Ok();
        }
    }
}
