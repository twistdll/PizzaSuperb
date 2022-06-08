﻿using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

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
            double totalPrice = await GetTotalPrice(salePairs);

            if(totalPrice <= 0)
                return false;

            var order = new Order()
            {
                DateCreated = DateTime.Now,
                TotalPrice = totalPrice,
                Address = address,
                UserId = userEntity.Id
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
        {
            var product = await _uow.PizzaTypes.GetAsync(x => x.Name == name);
            
            if(product?.Discount != null && product?.Price != null)
                return product.Price * (1 - product.Discount);

            return product?.Price;
        }

        public async Task<bool> GetActiveDeliveryStatus(UserDTO? user)
        {
            var userEntity = _mapper.Map<User>(user);

            if (userEntity == null)
                return false;

            var orders =  await _uow.Orders.GetAllAsync(x => x.UserId == user.Id && x.IsDelivered == false);
            return orders.Any();
        }

        #region Private methods

#warning need to encapsulate init params logic in DAL smh
        private async Task<double> GetTotalPrice(Dictionary<string, string> pairs)
        {
            var outParam = new SqlParameter()
            {
                ParameterName = "@totalPrice",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Output
            };

            var data = new DataTable();
            data.Columns.Add("Name", typeof(string));
            data.Columns.Add("Count", typeof(int));

            foreach (var item in pairs)
            {
                data.Rows.Add(item.Key, int.Parse(item.Value));
            }

            var inParam = new SqlParameter()
            {
                ParameterName = "@pairs",
                SqlDbType = SqlDbType.Structured,
                Value = data,
                TypeName = "NameCountPairs"
            };

            await _uow.QueryService.ExecuteStoredProcedureAsync("[dbo].[ItemsTotalSum] @pairs, @totalPrice OUTPUT", 
                                                                inParam, 
                                                                outParam);
            return (double)outParam.Value;
        }

        #endregion
    }
}
