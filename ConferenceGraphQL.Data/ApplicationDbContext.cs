using Microsoft.EntityFrameworkCore;

namespace ConferenceGraphQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public DbSet<Speaker> Speakers { get; set; }
    }
}
