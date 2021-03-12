using Case_Grupo_Technos.Models;
using Microsoft.EntityFrameworkCore;

namespace Case_Grupo_Technos.Data
{

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }

}