using AutoMapper;
using Pagos.Models;
using Pagos.Models.Dtos;

namespace Pagos.PagosMapper
{
    public class PagosMapper: Profile
    {
        public PagosMapper()
        {
            CreateMap<fPagoContribAseIdep, fPagoContribAseldepDto>().ReverseMap();
        }
    }
}
