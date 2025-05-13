using System.Reflection;
using Costumer.API.DTOs;
using Costumer.API.Profiles;
using Costumer.Aplication.DTO;
using Costumer.Aplication.Profiles;
using Costumer.Aplication.Services;
using Costumer.Aplication.Validations;
using Costumer.Domain.Repositories;
using Costumer.Infrastructure.DataBase;
using Costumer.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DBContext

builder.Services.AddDbContext<AppDBContext>(
    config =>
    {
        config.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Costumer;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
        b => b.MigrationsAssembly("Costumer.Infrastructure"));
    });
//Add Respositories
builder.Services.AddScoped<iCostumerRepository, CostumerRepository>();

builder.Services.AddControllers();

//Add Services
builder.Services.AddScoped<iCostumerServices, CostumerServices>();

//Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CostumerValidation>();

//Add Profiles
builder.Services.AddAutoMapper(typeof(CostumerEntityProfile));
builder.Services.AddAutoMapper(typeof(CostumerControllerProfile));

//Add MediatR
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    config.RegisterServicesFromAssembly(typeof(Register).Assembly);
});
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
