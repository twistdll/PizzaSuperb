using DAL.Entities;
using Microsoft.Data.SqlClient;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> Orders { get; }
        IRepository<Dopping> Doppings { get; }
        IRepository<OrderConfiguration> OrderConfigurations { get; }
        IRepository<PizzaType> PizzaTypes { get; }
        IRepository<Promocode> Promocodes { get; }
        IRepository<User> Users { get; }
  
        IQueryService QueryService { get; }
    }
}
