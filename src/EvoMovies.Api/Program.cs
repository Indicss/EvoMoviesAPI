using EvoMovies.Api.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddSingleton<MovieService>();
}

var app = builder.Build();
app.UseHttpsRedirection();

app.MapControllers();
app.Run();
