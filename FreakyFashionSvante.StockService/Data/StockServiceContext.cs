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
