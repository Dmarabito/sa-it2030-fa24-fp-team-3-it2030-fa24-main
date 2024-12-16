using Microsoft.EntityFrameworkCore;
using sa_it2030_fa24_fp_team_3_it2030_fa24.Models;

namespace sa_it2030_fa24_fp_team_3_it2030_fa24.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }

        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Organization> Organizations => Set<Organization>();
        public DbSet<Message> Messages => Set<Message>();


    }
}
