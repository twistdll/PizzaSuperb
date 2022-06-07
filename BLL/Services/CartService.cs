using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
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

        public async Task<bool> CreateOrder(UserDTO user,
                                Dictionary<string, string> salePairs,
                                string address)
        {
            var userEntity = _mapper.Map<User>(user);

#warning impl stored procedure for this
            double totalPrice = 0;
            foreach (var name in salePairs.Keys)
            {
                var dopping = new Dopping();
                var product = await _uow.PizzaTypes.GetAsync(x => x.Name == name);                      

                if(product == null)
                    dopping = await _uow.Doppings.GetAsync(x => x.Name == name);

                if (product == null 
                    || product.IsForSale == false 
                    || string.IsNullOrEmpty(salePairs[name]))
                    return false;

                totalPrice += (product.Price * int.Parse(salePairs[name]));
            }

            var order = new Order()
            {
                DateCreated = DateTime.Now,
                TotalPrice = totalPrice,
                Address = address,
                User = userEntity
            };

            _uow.Orders.Insert(order);
            return true;
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

        #region Private methods

        //private double GetTotalPrice<T>(List<string> names)
        //{ 


        //}

        #endregion
    }
}
