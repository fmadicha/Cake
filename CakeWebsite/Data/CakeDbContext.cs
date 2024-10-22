using CakeWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CakeWebsite.Data
{
    public class CakeDbContext:DbContext
    {
        public CakeDbContext(DbContextOptions<CakeDbContext>options):base(options) 
        {
                
        }

        public DbSet<Category> Categories { get; set; }
    }
}
