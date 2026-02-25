using EvoMovies.Api.Infrastructure.Persistence;
using EvoMovies.Api.Services;
using Microsoft.EntityFrameworkCore;

const string corsOrigin = "_evoMoviesOrigin";

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<MovieService>();
    
    builder.Services.AddDbContext<AppDbContext>(options => 
        options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDatabase")));
    
    var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins")?.Split(',') ?? [];
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(corsOrigin, policy =>
        {
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });
}

var app = builder.Build();
app.UseCors(corsOrigin);
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
