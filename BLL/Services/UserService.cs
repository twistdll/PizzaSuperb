using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserDTO?> GetUser(string email, string password)
        {
            var entity = await _uow.Users.GetAsync(x 
                                          => x.Email == email && x.Password == password);

            var user = _mapper.Map<UserDTO>(entity);
            return user;
        }
    }
}
