using System;
using Parcial.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Parcial.Infrastructure.DataBase;
using Parcial.Infrastructure.Repositories;
using Parcial.Aplication.Services;
using Parcial.Aplication.Validations;
using FluentValidation;
using Parcial.Aplication.Profiles;
using Parcial.API.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDBContext>(
    config =>
    {
        config.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductClase4DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
        b => b.MigrationsAssembly("Parcial.Infrastructure"));
    });

//Add Respositories

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<iCostumerRepository, CostumerRepository>();

builder.Services.AddControllers();

//Add Services

builder.Services.AddScoped<iProductServices, ProductServices>();

//Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

//Add Profiles
builder.Services.AddAutoMapper(typeof(ProductProfiles));
builder.Services.AddAutoMapper(typeof(ProductControllerProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Add DbContext





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
