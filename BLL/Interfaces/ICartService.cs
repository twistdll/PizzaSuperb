using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ICartService
    {
        Task<bool> CreateOrder(UserDTO user,
                               Dictionary<string,string> salePairs,
                               string address);
        //Task<List<DoppingDTO>> GetDoppings();
        Task<string?> GetPhotoByName(string name);
        Task<double?> GetPriceByName(string name);
        Task<bool> GetActiveDeliveryStatus(UserDTO? user);
    }
}
