using Pagos.Data;
using Pagos.Models;
using Pagos.Repository.IRepository;

namespace Pagos.Repository
{
    public class fPagoContribAseIdepRepository : IfPagoContribAseIdepRepository
    {
        private readonly AplicationDbContext _bd;


        public fPagoContribAseIdepRepository(AplicationDbContext bd)
        {
            _bd = bd;
        }
        public bool ActualizarFormulario(fPagoContribAseIdep formulario)
        {
            _bd.fPagoContribAseldeps.Update(formulario);
            return Guardar();
        }

        public bool BorrarFormulario(fPagoContribAseIdep formulario)
        {
            _bd.fPagoContribAseldeps.Remove(formulario);
            return Guardar();
        }

        public bool CrearFormulario(fPagoContribAseIdep formulario)
        {
            _bd.fPagoContribAseldeps.Add(formulario);
            return Guardar();
        }

        public ICollection<fPagoContribAseIdep> GetFormularios()
        {
            return _bd.fPagoContribAseldeps.OrderBy(c => c.Id).ToList();
        }

        public fPagoContribAseIdep GetFormulario(int formId)
        {
            return _bd.fPagoContribAseldeps.FirstOrDefault(c => c.Id == formId);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public bool ExisteFormulario(string primerNombre)
        {
            bool valor = _bd.fPagoContribAseldeps.Any(c => c.primerNombre.ToLower().Trim() == primerNombre.ToLower().Trim());
            return valor;
        }

        public bool ExisteFormulario(int id)
        {
            return _bd.fPagoContribAseldeps.Any(c => c.Id == id);
        }
    }
}
