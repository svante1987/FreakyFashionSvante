using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionSvante.StockService.Controllers
{
    //TODO: Kalla denna för StockLevel?
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpPut("{articleNumber}")]
        public IActionResult UpdateStockLevel(string articleNumber, UpdateStockLevelDto updateStockLevelDto)
        {
            return NoContent();
        }
    }
}
