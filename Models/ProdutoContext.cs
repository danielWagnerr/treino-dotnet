using Microsoft.EntityFrameworkCore;
namespace ProvaAPI.Models
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
        : base(options)
    {}


public DbSet<ProdutoItem> ProdutoItems { get; set; }
}
}