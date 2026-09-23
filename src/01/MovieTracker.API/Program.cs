using FluentValidation;
using MovieTracker.Application.Common.Repositories;
using MovieTracker.Application.Movies.GetMovieList;
using MovieTracker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMovieRepository, InMemoryMovieRepository>();
builder.Services.AddScoped<GetMovieListHandler>();
builder.Services.AddScoped<IValidator<GetMovieListRequest>, GetMovieListValidator>();

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
builder.Services.AddCors(options =>
{
    options.AddPolicy("MovieTrackerWeb", policy =>
        policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("MovieTrackerWeb");
app.MapGetMovieListEndpoint();

app.Run();

public partial class Program;
