using Innofactor.EfCoreJsonValueConverter;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_Review.Models;
using System.Reflection.Emit;

namespace Movie_Review.Data
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>()
              .Property(m => m.Ratings)
              .HasJsonValueConversion();

            builder.Entity<Review>()
                .HasOne(review => review.Movies)
                .WithMany(movie => movie.Reviews)
                .HasForeignKey(review => review.imdbID);

            builder.Entity<Review>()
                .HasOne(review => review.User)
                .WithMany(user => user.Reviews)
                .HasForeignKey(review => review.UserId);
            builder.Entity<Like>()
                .HasOne(like => like.Review)
                .WithMany(review => review.Likes)
                .HasForeignKey(like => like.ReviewId);
            builder.Entity<Like>()
                .HasOne(like => like.User)
                .WithMany(user => user.Likes)
                .HasForeignKey(like => like.UserId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Like> Likes { get; set; }
    } 
}
