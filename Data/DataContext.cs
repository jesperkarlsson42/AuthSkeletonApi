using AspNetAuthApi.Services;
using Microsoft.EntityFrameworkCore;

namespace AspNetAuthApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
    }
}