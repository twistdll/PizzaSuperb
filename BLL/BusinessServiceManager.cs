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
    }
}
