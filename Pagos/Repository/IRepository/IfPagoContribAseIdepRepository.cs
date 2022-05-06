using Pagos.Models;

namespace Pagos.Repository.IRepository
{
    public interface IfPagoContribAseIdepRepository
    {
        ICollection<fPagoContribAseIdep> GetFormularios();

        fPagoContribAseIdep GetFormulario(int formId);

        bool CrearFormulario(fPagoContribAseIdep formulario);

        bool ActualizarFormulario(fPagoContribAseIdep formulario);

        bool BorrarFormulario(fPagoContribAseIdep formulario);

        bool Guardar();

        bool ExisteFormulario(string nombre);

        bool ExisteFormulario(int id);
    }

}
