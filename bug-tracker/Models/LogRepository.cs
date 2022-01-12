namespace bug_tracker.Models
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    { 
        public LogRepository(AppDbContext appDbContext) : base(appDbContext){}

    }
}