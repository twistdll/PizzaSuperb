using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Utils.Automapper.Profiles
{
    internal class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();

            CreateMap<Order, OrderDTO>()
                .ReverseMap();
        }
    }
}
