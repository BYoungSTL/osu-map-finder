using OsuMapFinder.Data.Entities;
using OsuMapFinder.Data.Interfaces.BaseService;

namespace OsuMapFinder.Data.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserByName(string username);
    }
}
