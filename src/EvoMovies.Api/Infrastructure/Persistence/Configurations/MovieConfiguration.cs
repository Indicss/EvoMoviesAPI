using EvoMovies.Api.Domain.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvoMovies.Api.Infrastructure.Persistence.Configurations;

public sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movies");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Director)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Rating)
            .HasPrecision(4, 2)
            .IsRequired();

        builder.Property(x => x.ReleaseDate)
            .IsRequired();

        builder.Property(x => x.Genre)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.Poster)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Url)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();
    }
}