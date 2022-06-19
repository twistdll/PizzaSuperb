using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Utils.Automapper.Profiles
{
    internal class ShowcaseProfile : Profile
    {
        public ShowcaseProfile()
        {
            CreateMap<Product, PizzaTypeDTO>()
                .ForMember(dst  => dst.OldPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Price * (1 - (src.Discount ?? 0))));
        }
    }
}
