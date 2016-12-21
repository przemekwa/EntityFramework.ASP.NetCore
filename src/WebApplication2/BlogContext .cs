
namespace WebApplication2
{
    using Microsoft.EntityFrameworkCore;

    public class BlogContext : DbContext
    {
       

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blogs");
        
        }

        public DbSet<Blog> Goros { get; set; }

        
    }
}