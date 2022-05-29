using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Utils.Automapper.Profiles
{
    internal class ShowcaseProfile : Profile
    {
        public ShowcaseProfile()
        {
            CreateMap<PizzaType, PizzaTypeDTO>()
                .ForMember(dst => dst.DiscountedPrice, opt => opt.MapFrom(src => src.Price * (1 - (src.Discount ?? 0))));
        }
    }
}
