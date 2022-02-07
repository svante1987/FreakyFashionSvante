using FreakyFashionSvante.StockService.Data;
using FreakyFashionSvante.StockService.Models.Domain;
using FreakyFashionSvante.StockService.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionSvante.StockService.Controllers
{
    //TODO: Kalla denna för StockLevel?
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        public StockController(StockServiceContext context)
        {
            Context = context;
        }

        private StockServiceContext Context { get; }
        [HttpPut("{articleNumber}")]
        public IActionResult UpdateStockLevel(string articleNumber, UpdateStockLevelDto updateStockLevelDto)
        {
            var stockLevel = new StockLevel(
                updateStockLevelDto.ArticleNumber,
                updateStockLevelDto.StockLevel
                );

            Context.StockLevel.Add(stockLevel);

            Context.SaveChanges();

            return NoContent();
        }
        
        [HttpGet]
        public IEnumerable<StockLevelDto> GetAll()
        {
            var stockLevelDtos = Context.StockLevel.Select(x => new StockLevelDto
            {
                ArticleNumber = x.ArticleNumber,
                Stock = x.Stock,
            });
            return stockLevelDtos;
        }
    }

    public class StockLevelDto 
    { 
    public string ArticleNumber { get; set; }

    public int Stock { get; set; }
    }

}
