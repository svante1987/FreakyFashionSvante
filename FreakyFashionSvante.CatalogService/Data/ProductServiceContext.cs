using FreakyFashionSvante.CatalogService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionSvante.CatalogService.Data
{
    public class ProductServiceContext : DbContext
    {
        public DbSet<ProductLevel> ProductLevel{get; set;}

    public ProductServiceContext(DbContextOptions<ProductServiceContext> options)
        : base(options)
    {

    }

    }
}
