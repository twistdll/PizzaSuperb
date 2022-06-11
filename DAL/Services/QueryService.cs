using DAL.Context;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DAL.Services
{
    internal class QueryService : IQueryService
    {
        private readonly ApplicationContext _db;

        public QueryService(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<double> GetTotalPriceOfItems(Dictionary<string, string> nameCountPairs)
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

            foreach (var item in nameCountPairs)
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

            await ExecuteStoredProcedureAsync("[dbo].[ItemsTotalSum] @pairs, @totalPrice OUTPUT",
                                             inParam,
                                             outParam);
            return (double)outParam.Value;
        }

        #region Private methods

        private async Task ExecuteStoredProcedureAsync(string nameWithParams, params SqlParameter[] parameters)
        {
            await _db.Database.ExecuteSqlRawAsync("EXEC " + nameWithParams, parameters);

        }

        #endregion
    }
}
