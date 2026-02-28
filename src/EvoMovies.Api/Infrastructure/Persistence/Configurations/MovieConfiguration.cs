using EvoMovies.Api.Domain.Movies;
using EvoMovies.Api.Domain.Movies.Enums;
using EvoMovies.Api.Infrastructure.Persistence.Configurations.Convertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvoMovies.Api.Infrastructure.Persistence.Configurations;

internal sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies")
               .HasKey(t => t.Id);
        
        builder.Property(t => t.Id)
               .ValueGeneratedNever();

        builder.Property(t => t.Title)
               .HasMaxLength(50)
               .IsRequired();
        
        builder.Property(t => t.Genre)
               .HasMaxLength(20)
               .HasConversion(
                   appValue => appValue.ToString(),
                   dbValue => (Genre)Enum.Parse(typeof(Genre), dbValue)
               )
               .IsRequired();
        
        builder.Property(t => t.Director)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(t => t.Poster)
               .HasMaxLength(300)
               .IsRequired();
        
        builder.Property(t => t.Url)
               .HasMaxLength(200)
               .IsRequired();
        
        builder.Property(t => t.ReleaseDate)
               .HasConversion<DateOnlyConverter>()
               .IsRequired();

        builder.Property(t => t.CreatedAt)
               .HasConversion<DateTimeConverter>()
               .IsRequired();
    }
}