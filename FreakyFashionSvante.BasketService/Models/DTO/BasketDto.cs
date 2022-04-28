namespace FreakyFashionSvante.BasketService.Models.DTO
{
    public class BasketDto
    {
    public string Identifier { get; set; }
    public ICollection<UpdateBasketDto> BasketItems { get; set; }
    }
}
