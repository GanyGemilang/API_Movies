using Microsoft.EntityFrameworkCore;
using Movies_xsis.Entities;
using Movies_xsis.Repositories;
using MySql.EntityFrameworkCore.Extensions;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MovieRepository>();

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
if (conString != null || conString =="")
{
    builder.Services.AddEntityFrameworkMySQL().AddDbContext<DbtestContext>(options =>
    {
        options.UseMySQL(conString);
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
