using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ICartService
    {
        Task<List<DoppingDTO>> GetDoppings();
    }
}
