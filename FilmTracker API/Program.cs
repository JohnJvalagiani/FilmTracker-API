using FilmTrackerAPI.Application;
using FilmTrackerAPI.Application.Middleware;
using FilmTrackerAPI.Application.Validators;
using FilmTrackerAPI.Domain.Interfaces;
using FilmTrackerAPI.Infrastructure;
using FilmTrackerAPI.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmTracker API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddTransient<IWatchlistRepository, WatchlistRepository>();
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddApplication();

builder.Services.AddControllers()
        .AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssemblyContaining<AddMovieToWatchlistCommandValidator>();
            fv.RegisterValidatorsFromAssemblyContaining<MarkMovieAsWatchedCommandValidator>();
            fv.RegisterValidatorsFromAssemblyContaining<SearchMovieByNameQueryValidator>();
        });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
