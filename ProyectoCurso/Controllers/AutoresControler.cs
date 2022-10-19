using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCurso.Controllers.Entidades;
using ProyectoCurso.Dtos;
using ProyectoCurso.Dtos.DtoResponse;
using System.Linq;

namespace ProyectoCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresControler : ControllerBase
    {
        public readonly ApplicationDbContext constext;
        private readonly IMapper mapper;

        public AutoresControler(ApplicationDbContext context,IMapper mapper)
        {
            this.constext = context;
            this.mapper = mapper;
        }

        //Api/autores
        // [HttpGet("listado")]//Api/autores/listado
        // [HttpGet("/listado")]//listado


        //[HttpGet("primero")]
        //public async Task<ActionResult<Autor>> PrimerAutor([FromHeader] int miValor, [FromQuery] string nombre)
        //{
        //    return await constext.Autores.FirstOrDefaultAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<List<AutorResponseDTO>>> GetAutores()
        {
            var autores = await constext.Autores.ToListAsync();
            return mapper.Map<List<AutorResponseDTO>>(autores);
        }

        //BUSCAR AUTOR POR SU ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AutorResponseDTO>> Get([FromRoute] int id)
        {
            var autor = await constext.Autores.FirstOrDefaultAsync(autorBD => autorBD.id == id);
            if (autor == null)
            {
                return NotFound();
            }
            return mapper.Map<AutorResponseDTO>(autor);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<AutorResponseDTO>>> Get([FromRoute] string nombre) 
        {
            var autores = await constext.Autores.Where(autorBD => autorBD.Nombre.Contains(nombre)).ToListAsync();
          
            return mapper.Map<List<AutorResponseDTO>>(autores);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorCreacionDTO autorCreacionDTO) {
            var existAutorDto = await constext.Autores.AnyAsync(x=>x.Nombre == autorCreacionDTO.Nombre);
            if (existAutorDto)
            { 
                return BadRequest($"Ya existe en autor con el nombre {autorCreacionDTO.Nombre}");
            }
            //mapeando el autor
            var autor = mapper.Map<Autor>(autorCreacionDTO);
            constext.Add(autor);
            await constext.SaveChangesAsync();
            return Ok(autor);
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
