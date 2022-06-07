using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;

namespace BLL
{
    internal class BusinessServiceManager : IBusinessServicesManager
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BusinessServiceManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        private IShowcaseService? _showcaseService;
        public IShowcaseService ShowcaseService => _showcaseService ??= new ShowcaseService(_uow, _mapper);

        private ICartService _cartService;
        public ICartService CartService => _cartService ??= new CartService(_uow, _mapper);

        private IUserService _userService;
        public IUserService UserService => _userService ??= new UserService(_uow, _mapper);
    }
}
