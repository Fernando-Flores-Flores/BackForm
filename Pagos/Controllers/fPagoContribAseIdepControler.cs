using AutoMapper;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagos.Data;
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
            if (_ctRepo.ExisteFormulario(formularioDto.Id))
            {
                ModelState.AddModelError("MotivoError", "El formulario ya existe");
                return StatusCode(404, ModelState);
            }
            var formulario = _mapper.Map<fPagoContribAseIdep>(formularioDto);
            if (!_ctRepo.CrearFormulario(formulario))
            {
                ModelState.AddModelError("MotivoError", $"Algo salio mal guardando el registro {formulario.Id}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetFormulario", new { formularioId = formulario.Id }, formulario);
        }


        [HttpGet("generarReportePdf")]
        public IActionResult generarReportePdf(string nombre)
        {
           // List<fPagoContribAseIdep> listaForm= listaFormu(nombre);
            using (MemoryStream ms = new MemoryStream())
            {
               PdfWriter writer=new PdfWriter(ms);
                using (PdfDocument pdfDoc = new PdfDocument(writer)) 
                { 
                    Document doc = new Document(pdfDoc);
                    Paragraph c1 = new Paragraph("Reporte personas");
                    doc.Add(c1);
                    doc.Close();
                    writer.Close();
                }
                String json = Convert.ToBase64String(ms.ToArray());
                if (json == null)
                {
                    return NotFound();
                }
                var w = new W
                {
                    valor = json,
                };
                return Ok(w);
            }
        }
        //public List<fPagoContribAseIdep> listaPersonas()
        //{
        //    AplicationDbContext bDReportesContext = new AplicationDbContext();
        //    return bDReportesContext.fPagoContribAseldeps.ToList();
        //}
        public class W
        {
            public string? valor { get; set; }
        }

    }
}
