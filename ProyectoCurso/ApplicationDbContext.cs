using Microsoft.EntityFrameworkCore;
using ProyectoCurso.Controllers.Entidades;

namespace ProyectoCurso
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

    }
}
