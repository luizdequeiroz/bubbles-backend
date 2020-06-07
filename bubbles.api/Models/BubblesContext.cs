using bubbles.api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace bubbles.api.Models
{
    public class BubblesContext : DbContext
    {
        public BubblesContext(DbContextOptions<BubblesContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}