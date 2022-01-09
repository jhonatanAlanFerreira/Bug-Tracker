using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bug_tracker.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupUser> GroupUser { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<LogType> LogType { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectGroup> ProjectGroup { get; set; }
        public DbSet<SubTask> SubTask { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<TaskSet> TaskSet { get; set; }
        public DbSet<TaskSetGroup> TaskSetGroup { get; set; }
        public DbSet<TaskState> TaskState { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }

    }
}