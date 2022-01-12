using System.Linq;
using bug_tracker.Classes;

namespace bug_tracker.Models
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public User GetByPassword(UserLogin userLogin)
        {
             User user = _appDbContext.User
            .Where(user => user.Login == userLogin.Login)
            .FirstOrDefault();

            if(!BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password)) return null;

            return user;
        }
    }
}