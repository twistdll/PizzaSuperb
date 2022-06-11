using Microsoft.Data.SqlClient;

namespace DAL.Interfaces
{
    public interface IQueryService
    {
        Task<double> GetTotalPriceOfItems(Dictionary<string,string> nameCountPairs);
    }
}
