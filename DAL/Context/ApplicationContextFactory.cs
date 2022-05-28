using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DAL.Context
{
    internal class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
#warning fix harcode
        public ApplicationContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=PizzaDb;Trusted_Connection=True;";
            return new ApplicationContext(connectionString);
        }
    }
}
