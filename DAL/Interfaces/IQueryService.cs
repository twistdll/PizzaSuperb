using Microsoft.Data.SqlClient;

namespace DAL.Interfaces
{
    public interface IQueryService
    {
        Task ExecuteStoredProcedureAsync(string nameWithParams, params SqlParameter[] parameters);
    }
}
