using fortes111.Models;
using Microsoft.EntityFrameworkCore;

namespace fortes111.Contexto
{ 
    public class apiContexto : DbContext
    {
        public apiContexto(DbContextOptions<apiContexto> options) : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }

    }
}
