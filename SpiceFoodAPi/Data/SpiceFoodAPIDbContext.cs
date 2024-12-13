using Microsoft.EntityFrameworkCore;
using SpiceApi.Model;
using SpiceS.Models;

namespace SpiceFoodAPi.Data
{
    public class SpiceFoodAPIDbContext: DbContext
    {
        public SpiceFoodAPIDbContext(DbContextOptions<SpiceFoodAPIDbContext> options)
           : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
    }
}
