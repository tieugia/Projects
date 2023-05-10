using Microsoft.EntityFrameworkCore;

namespace ModernisationChallenge.DAL
{
    public class ModerniseDbContext : DbContext
    {
        public ModerniseDbContext(DbContextOptions<ModerniseDbContext> options)
            : base(options)
        {
        }
        public DbSet<Entity.Task> Tasks { get; set; }
    }
}
