using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IShowcaseService
    {
        Task<List<PizzaTypeDTO>> GetSaleProducts();
    }
}
