using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Drawing> Drawings { get; set; }
    }
}
