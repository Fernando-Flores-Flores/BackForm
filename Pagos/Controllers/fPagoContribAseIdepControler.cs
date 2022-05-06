using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagos.Models;
using Pagos.Models.Dtos;
using Pagos.Repository.IRepository;

namespace Pagos.Controllers
{
    [Route("api/fPagoContribAseIdep")]
    [ApiController]
    public class fPagoContribAseIdepControler : Controller
    {
        private readonly IfPagoContribAseIdepRepository _ctRepo;
        private readonly IMapper _mapper;

        public fPagoContribAseIdepControler(IfPagoContribAseIdepRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetFormularios() 
        {
            var listaFormularios = _ctRepo.GetFormularios();
            var listaFormulariosDto = new List<fPagoContribAseldepDto>();
            foreach (var lista in listaFormularios)
            {
                listaFormulariosDto.Add(_mapper.Map<fPagoContribAseldepDto>(lista));
            }
            return Ok(listaFormulariosDto);
        }

        // GET: api/Categorias/5
        [HttpGet("{formularioId:int}", Name = "GetFormulario")]
        public IActionResult GetFormulario(int formularioId) { 
            var itemFormulario = _ctRepo.GetFormulario(formularioId);
            if (itemFormulario == null)
            {
                return NotFound();
            }
            var itemFormularioDto = _mapper.Map<fPagoContribAseldepDto>(itemFormulario);
            return Ok(itemFormularioDto);
        }


        [HttpPost]
        public IActionResult CrearFormulario([FromBody] fPagoContribAseldepDto formularioDto)
        {
            if (formularioDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_ctRepo.ExisteFormulario(formularioDto.primerNombre))
            {
                ModelState.AddModelError("", "El formulario ya existe");
                return StatusCode(404, ModelState);
            }
            var formulario = _mapper.Map<fPagoContribAseIdep>(formularioDto);
            if (!_ctRepo.CrearFormulario(formulario))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro {formulario.Id}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetFormulario", new { formularioId = formulario.Id }, formulario);
        }

    }
}
