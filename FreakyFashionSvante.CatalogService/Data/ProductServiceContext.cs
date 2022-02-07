
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionSvante.CatalogService.Data
{
    public class ProductServiceContext : DbContext
    {
        public DbSet<ProductLevel>{get; set;}

    public ProductServiceContext(DbContextOptions<ProductServiceContext> options)
        : base(options)
    {

    }

    }
}
