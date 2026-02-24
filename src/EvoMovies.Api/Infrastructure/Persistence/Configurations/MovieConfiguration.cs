using EvoMovies.Api.Domain.Movies;
using EvoMovies.Api.Domain.Movies.Enums;
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
        
        builder.Property(t => t.ReleaseDate)
               .HasConversion(
                      d => d.ToDateTime(TimeOnly.MinValue).ToUniversalTime(),
                      d => DateOnly.FromDateTime(d.ToLocalTime())
               )
               .IsRequired();

        builder.Property(t => t.CreatedAt)
               .HasConversion(
                      domainValue => domainValue.ToUniversalTime(), 
                      dbValue => dbValue.ToLocalTime())
               .IsRequired();
    }
}