using Microsoft.EntityFrameworkCore;
using SaifApi.Model;


namespace SaifApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
