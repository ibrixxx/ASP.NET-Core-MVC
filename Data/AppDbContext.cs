using Microsoft.EntityFrameworkCore;
using miniproject.Models;

namespace miniproject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {   
            
        }

        public DbSet<MyModel> MyTable {get; set;}
    }
}