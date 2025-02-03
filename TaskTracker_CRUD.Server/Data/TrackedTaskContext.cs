using Microsoft.EntityFrameworkCore;
using TaskTracker_CRUD.Server.Models;

namespace TaskTracker_CRUD.Server.Data
{
    public class TrackedTaskContext : DbContext
    {
        public TrackedTaskContext(DbContextOptions<TrackedTaskContext> options) : base(options) { }

        public DbSet<TrackedTask> Examples { get; set; }
    }
}
