using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Services;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;

        #region Repos
        private GenericRepository<Order> _orders;
        private GenericRepository<OrderConfiguration> _orderConfigurations;
        private GenericRepository<Product> _products;
        private GenericRepository<Promocode> _promocodes;
        private GenericRepository<User> _users;
        #endregion

        #region Services
        private QueryService _queryService;
        #endregion

        public UnitOfWork(string connectionString)
        {
            _db = new ApplicationContext(connectionString);                   
        }

        public IQueryService QueryService
        {
            get
            {
                if (_queryService == null)
                    _queryService = new QueryService(_db);

                return _queryService;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new GenericRepository<Order>(_db);

                return _orders;
            }
        }
        
        public IRepository<OrderConfiguration> OrderConfigurations
        {
            get
            {
                if (_orderConfigurations == null)
                    _orderConfigurations = new GenericRepository<OrderConfiguration>(_db);

                return _orderConfigurations;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (_products == null)
                    _products = new GenericRepository<Product>(_db);

                return _products;
            }
        }

        public IRepository<Promocode> Promocodes
        {
            get
            {
                if (_promocodes == null)
                    _promocodes = new GenericRepository<Promocode>(_db);

                return _promocodes;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (_users == null)
                    _users = new GenericRepository<User>(_db);

                return _users;
            }
        }

        public void Dispose()
        { 
            GC.SuppressFinalize(this);
        }      
    }
}
