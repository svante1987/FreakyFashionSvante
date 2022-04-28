using AutoMapper;
using FreakyFashionSvante.OrderService.Data;
using FreakyFashionSvante.OrderService.Models.Domain;
using FreakyFashionSvante.OrderService.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FreakyFashionSvante.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(OrderContext context, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<ActionResult<OrderCreatedDto>> Order(OrderCreateDto order)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var httpResponse = await httpClient.GetAsync($"http://localhost:6000/api/basket/{order.Identifier}");

            var content = await httpResponse.Content.ReadAsStringAsync();

            var basket = JsonSerializer.Deserialize<BasketDto>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (basket?.Identifier == null)
                return NotFound(new { message = "Basket not found" });
            if (basket.BasketItems == null)
                return NotFound(new { message = "Basket is empty" });

            var createdOrder = await _context.Orders.AddAsync(new Order()
            {
                Customer = order.Customer,
                OrderLines = basket.BasketItems.Select
                (item => new OrderLine
                {
                    Item = item.ProductId,
                    Quantity = Convert.ToInt32(item.Quantity)
                }).ToList()
            });

            await _context.SaveChangesAsync();

            return Created("", new OrderCreatedDto { OrderId = createdOrder.Entity.Id, });
        }

    }
}
