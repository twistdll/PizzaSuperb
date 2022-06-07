using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> GetUser(string email, string password);
    }
}
