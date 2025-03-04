using Microsoft.EntityFrameworkCore;

namespace ChanelCategorySearcher.DAI;

public sealed class AppDbContext : DbContext
{
    public DbSet<Chanel> Chanels { get; set; } = null!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chanel>().HasKey(x => x.Id);
        modelBuilder.Entity<Chanel>().Property(x => x.Category).HasMaxLength(100);
        modelBuilder.Entity<Chanel>().Property(x => x.Name).HasMaxLength(100);
        modelBuilder.Entity<Chanel>().Property(x => x.Link).HasMaxLength(100);
        
        modelBuilder.Entity<Chanel>().HasData(
            new Chanel { Id = 1, Name = "Tom", Category = "IT", Link = "url"},
            new Chanel { Id = 2, Name = "Bob", Category = "Auto", Link = "url"},
            new Chanel { Id = 3, Name = "Sam", Category = "Engineer", Link = "url" }
        );
    }
}