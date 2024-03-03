using Microsoft.EntityFrameworkCore;
using SampleApiBackend.Models;

namespace SampleApiBackend.Database
{
    public class SoapDbContext : DbContext
    {
        public SoapDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Soap> Soaps { get; set; }
    }
}
