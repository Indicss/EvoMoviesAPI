using EvoMovies.Api.Infrastructure.Persistence;
using EvoMovies.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<MovieService>();
    
    builder.Services.AddDbContext<AppDbContext>(options => 
        options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDatabase")));
}

var app = builder.Build();
app.UseHttpsRedirection();

app.MapControllers();
app.Run();
