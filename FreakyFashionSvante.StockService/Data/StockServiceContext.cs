using FreakyFashionSvante.StockService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionSvante.StockService.Data
{
    public class StockServiceContext: DbContext
    {
        public DbSet<StockLevel> StockLevel { get; set; }

        public StockServiceContext(DbContextOptions<StockServiceContext> options)
            : base(options)
        {

        }
        
    }
}
/*int Id { get; set; }
        string Name { get; set; }  
        string Description { get; set; }
        string ImageUrl { get; set; }
        int Price { get; set; }
        string ArticleNumber { get; set; }
        string UrlSlug { get; set; }*/