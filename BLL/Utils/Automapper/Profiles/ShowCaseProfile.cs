using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Utils.Automapper.Profiles
{
    internal class ShowCaseProfile : Profile
    {
        public ShowCaseProfile()
        {
            CreateMap<PizzaType, PizzaTypeDTO>()
                .ForMember(dst => dst.TotalPrice, opt => opt.MapFrom(src => src.Price * (src.Discount ?? 1)));
        }
    }
}
