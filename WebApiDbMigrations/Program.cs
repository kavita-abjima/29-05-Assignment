using Microsoft.EntityFrameworkCore;
using WebApiDbMigrations;
using Microsoft.Extensions.DependencyInjection;
using WebApiDbMigrations.Data;
using AutoMapper;
using WebApiDbMigrations.Models;
using WebApiDbMigrations.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebApiDbMigrationsContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDbMigrationsContext") ?? throw new InvalidOperationException("Connection string 'WebApiDbMigrationsContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Employee.EmpMapping.APIMapping));
builder.Services.AddTransient<IEmpRepository, Repository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
