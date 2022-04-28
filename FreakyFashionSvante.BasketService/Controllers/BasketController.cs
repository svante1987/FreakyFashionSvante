using FreakyFashionSvante.BasketService.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace FreakyFashionSvante.BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        public BasketController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpGet("{basketId}")]
        public async Task<ActionResult<BasketDto>> GetBasket(string basketId)
        {
            var basket = await _cache.GetStringAsync(basketId);
            if (basket == null)
                return NotFound();

            var result = JsonSerializer.Deserialize<BasketDto>(basket);

            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<BasketDto>> UpdateBasket(BasketDto basket)
        {
            await _cache.SetStringAsync(basket.Identifier, JsonSerializer.Serialize(basket));
            return await GetBasket(basket.Identifier);
        }
    }
}
