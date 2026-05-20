using FirstProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(book => book.Id);
            entity.Property(book => book.Title).IsRequired().HasMaxLength(120);
            entity.Property(book => book.Author).IsRequired().HasMaxLength(80);
            entity.Property(book => book.Price).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Price = 32.90m },
            new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Price = 29.50m }
        );
    }
}