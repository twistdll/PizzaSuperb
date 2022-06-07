namespace BLL.Interfaces
{
    public interface IBusinessServicesManager
    {
        IShowcaseService ShowcaseService { get; }
        ICartService CartService { get; }
        IUserService UserService { get; }
    }
}
