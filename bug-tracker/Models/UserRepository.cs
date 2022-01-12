using System.Linq;
using bug_tracker.Classes;

namespace bug_tracker.Models
{
    public class UserRepository : BaseRepository<User>, IUserRepository 
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public User GetByPassword(UserLogin userLogin)
        {
            var userOrganization = _appDbContext.User
           .Join(_appDbContext.Organization,
           user => user.OrganizationId,
           organization => organization.Id,
           (userRes, organizationRes) => new { User = userRes, Organization = organizationRes })
           .Where(userOrganization => userOrganization.User.Login == userLogin.Login)
           .Where(userOrganization => userOrganization.Organization.NickName == userLogin.OrgNickName)
           .FirstOrDefault();

            if (userOrganization == null || !BCrypt.Net.BCrypt.Verify(userLogin.Password, userOrganization.User.Password)) return null;

            return userOrganization.User;
        }
    }
}