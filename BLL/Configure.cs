using DAL;
using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class Configure
    {
        public static void AddBLL(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUnitOfWork>(_ => new UnitOfWork(connectionString));
        }
    }
}