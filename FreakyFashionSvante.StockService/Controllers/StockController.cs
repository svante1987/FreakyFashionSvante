using FreakyFashionSvante.StockService.Data;
using FreakyFashionSvante.StockService.Models.Domain;
using FreakyFashionSvante.StockService.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionSvante.StockService.Controllers
{
    
    [Route("api/[controller]")] //URL
    [ApiController]
    public class StockController : ControllerBase
    {
        public StockController(StockServiceContext context)
        {
            Context = context;
        }

        private StockServiceContext Context { get; }
        [HttpPut("{articleNumber}")] //Lägger till artikelnummer och hur många som finns i lager.
        public IActionResult UpdateStockLevel(string articleNumber, UpdateStockLevelDto updateStockLevelDto)
        {

            var stockLevel = Context.StockLevel.FirstOrDefault(x => x.ArticleNumber == updateStockLevelDto.ArticleNumber);

            if (stockLevel == null) //Om stockLevel är null så genereras en insert into
            {
                 stockLevel = new StockLevel(
                    updateStockLevelDto.ArticleNumber,
                    updateStockLevelDto.StockLevel
                );
                Context.StockLevel.Add(stockLevel);
            }
            else // om stockLevel inte är null så kommer nedan kod generera en update istället när vi kör SaveChanges()
            {
                stockLevel.Stock = updateStockLevelDto.StockLevel;
            }
            Context.SaveChanges();

            return NoContent();
        }
        
        [HttpGet] //Hämtar artikelnummer och antal i lager
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
