using Microsoft.EntityFrameworkCore;
using TaskTracker_CRUD.Server.Models;

namespace TaskTracker_CRUD.Server.Data
{
    public class RedditCommentsContext : DbContext
    {
        public RedditCommentsContext(DbContextOptions<RedditCommentsContext> options) : base(options) { }

        public DbSet<RedditComments> RedditComments { get; set; }
    }
}

