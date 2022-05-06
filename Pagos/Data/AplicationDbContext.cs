using Microsoft.EntityFrameworkCore;
using Pagos.Models;

namespace Pagos.Data
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base(options) 
        {

        }
        public DbSet<fPagoContribAseIdep> fPagoContribAseldeps { get; set; }
    }
}
