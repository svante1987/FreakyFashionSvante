using FreakyFashionSvante.CatalogService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionSvante.CatalogService.Data
{
    public class ProductServiceContext : DbContext
    {

    public ProductServiceContext(DbContextOptions<ProductServiceContext> options)
        : base(options)
    {

    }
        public DbSet<Product> Product{get; set;}

    }
}
