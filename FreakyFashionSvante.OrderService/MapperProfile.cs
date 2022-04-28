using AutoMapper;
using FreakyFashionSvante.OrderService.Models.Domain;
using FreakyFashionSvante.OrderService.Models.DTO;

namespace FreakyFashionSvante.OrderService
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BasketDto, Order>()
                .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.BasketItems));
            CreateMap<BasketItemDto, OrderLine>();
        }
    }
}
