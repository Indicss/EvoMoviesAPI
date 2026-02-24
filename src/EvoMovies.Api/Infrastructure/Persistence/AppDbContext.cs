using EvoMovies.Api.Domain.Movies;
using Microsoft.EntityFrameworkCore;

namespace EvoMovies.Api.Infrastructure.Persistence;

/*
    docker run --name EvoMoviesDb -p 5432:5432 -e "TZ=Europe/Chisinau" -e "POSTGRES_DB=EvoMovies" -e "POSTGRES_USER=evo-movies" -e "POSTGRES_PASSWORD=3lu6soDGQ1av" -d -v evo-movies-vol:/var/lib/postgresql/data  postgres:18.2-alpine 

    dotnet ef migrations add Initial -o Infrastructure/Persistence/Migrations
    dotnet ef database update
*/

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; private init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}