using TreinamentoTestesCore.Domain.Interfaces;
using TreinamentoTestesCore.Domain.Services;
using TreinamentoTestesCore.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;

// Adiciona as classes de servi�o e reposit�rio como depend�ncias

// Servi�os do dom�nio
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IOrderService, OrderService>();

// Reposit�rios
services.AddScoped<IOrderRepository, OrderRepository>();

services.AddControllers();

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
