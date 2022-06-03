using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    internal class CartService : ICartService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;


        public CartService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<DoppingDTO>> GetDoppings()
        {
            var entities = await _uow.Doppings.GetAllAsync();
            var dtos = _mapper.Map<List<DoppingDTO>>(entities);

            return dtos;
        }

        //maybe add check for IsForSale flag
        public async Task<string?> GetPhotoByName(string name)
            => (await _uow.PizzaTypes.GetAsync(x => x.Name == name))?.PhotoUrl;

        public async Task<double?> GetPriceByName(string name)
            => (await _uow.PizzaTypes.GetAsync(x => x.Name == name))?.Price;
    }
}
