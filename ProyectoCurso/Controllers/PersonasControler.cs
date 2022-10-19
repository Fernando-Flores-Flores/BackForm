using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCurso.Controllers.Entidades;
using ProyectoCurso.Dtos;
using ProyectoCurso.Dtos.DtoResponse;

namespace ProyectoCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasControler : ControllerBase
    {
        private readonly ApplicationDbContext _personasControlerContext;
        private readonly IMapper mapper;

        public PersonasControler(ApplicationDbContext context, IMapper mapper)
        {
            this._personasControlerContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonaResponseDto>>> GetPersonas()
        {
            var personas= await _personasControlerContext.Personas.ToListAsync();
            return mapper.Map<List<PersonaResponseDto>>(personas);
        }
    

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonaCreacionDto personaCreacionDto)
        {
            var personas = this.mapper.Map<Personas>(personaCreacionDto);
            _personasControlerContext.Add(personas);
            await _personasControlerContext.SaveChangesAsync();
            return Ok(personas);
        }
           
    
    
    }
}
