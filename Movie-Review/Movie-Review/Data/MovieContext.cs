using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;
using Movie_Review.Models;
namespace Movie_Review.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts)
        : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Movie>()
          .Property(m => m.Ratings)
          .HasJsonValueConversion();
    }

    public DbSet<Movie> Movies { get; set; }
}
