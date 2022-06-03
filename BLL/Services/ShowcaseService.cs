using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    internal class ShowcaseService : IShowcaseService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ShowcaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<PizzaTypeDTO>> GetSaleProducts(string? name = "")
        {           
            var entities = name is null
                           ? await _uow.PizzaTypes.GetAllAsync(x => x.IsForSale)
                           : await _uow.PizzaTypes.GetAllAsync(x => x.IsForSale && x.Name.Contains(name));
            
            var dtos = _mapper.Map<List<PizzaTypeDTO>>(entities);
            return dtos;
        }
    }
}
