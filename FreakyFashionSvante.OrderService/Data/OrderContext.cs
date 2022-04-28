using FreakyFashionSvante.OrderService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionSvante.OrderService.Data
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public OrderContext(DbContextOptions options) : base(options) { }
    }
}
