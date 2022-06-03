using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ICartService
    {
        Task<List<DoppingDTO>> GetDoppings();
        Task<string?> GetPhotoByName(string name);
        Task<double?> GetPriceByName(string name);
    }
}
