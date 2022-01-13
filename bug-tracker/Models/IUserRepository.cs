using bug_tracker.Classes;

namespace bug_tracker.Models
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User GetByPassword(UserLogin userLogin);
        User FindByToken(string token);
    }
}