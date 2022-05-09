using MediatR;
using Microsoft.OpenApi.Models;
using ShopItBackend.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopItBackend API", Version = "v1" });
});
builder.Services.AddScoped<IShopItDBContext, ShopItDBContext>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(u => u.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopItBackend API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
