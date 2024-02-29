using Microsoft.EntityFrameworkCore;
using SampleApiBackend.Models;

namespace SampleApiBackend.Database
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
