
namespace WebApplication2
{
    using Microsoft.EntityFrameworkCore;

    public class BlogContext : DbContext
    {
        private readonly string _connectionString;

        public BlogContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blogs");
        }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}