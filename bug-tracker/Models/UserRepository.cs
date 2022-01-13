using System.Linq;
using bug_tracker.Classes;
using Microsoft.EntityFrameworkCore;

namespace bug_tracker.Models
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            AddColumnGuard<User>("OrganizationId");
            AddColumnGuard<User>("UserTypeId");
        }

        public User GetByPassword(UserLogin userLogin)
        {
            var userOrganization = _appDbContext.User.
            AsNoTracking()
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

        public User FindByToken(string token)
        {
            return _appDbContext.User
            .AsNoTracking()
            .Where(u => u.Token == token).FirstOrDefault();
        }
    }
}