using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class CartService: ICartService
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
    }
}
