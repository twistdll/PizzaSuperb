using DAL.Context;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    internal class QueryService : IQueryService
    {
        private readonly ApplicationContext _db;

        public QueryService(ApplicationContext db)
        {
            _db = db;
        }

        public async Task ExecuteStoredProcedureAsync(string nameWithParams, params SqlParameter[] parameters)
        {
            await _db.Database.ExecuteSqlRawAsync("EXEC " + nameWithParams, parameters);
        }
    }
}
