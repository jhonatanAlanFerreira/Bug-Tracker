namespace bug_tracker.Models
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}