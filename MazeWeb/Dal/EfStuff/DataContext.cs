using MazeWebCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.EfStuff
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasMany(x => x.Games).WithOne(x => x.Gamer).OnDelete(DeleteBehavior.Cascade);
        }
    }
}