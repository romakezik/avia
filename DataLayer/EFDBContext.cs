using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Airlines> Airlines { get; set; }
        public DbSet<Destinations> Destinations { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderedTickets> OrderedTickets { get; set; }

    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseMySQL("server = localhost; database = t; user = root; password = root; ", b => b.MigrationsAssembly("DataLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }
}