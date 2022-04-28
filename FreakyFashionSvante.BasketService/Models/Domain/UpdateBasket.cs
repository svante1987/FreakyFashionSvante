using FreakyFashionSvante.BasketService.Models.DTO;

namespace FreakyFashionSvante.BasketService.Models.Domain
{
    public class UpdateBasket
    {
        public string ProductId { get; set; }
        public ICollection<UpdateBasketDto> Items { get; set; }
    }
}
