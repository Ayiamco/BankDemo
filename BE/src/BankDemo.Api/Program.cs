using BankDemo.Api.Data.DbContexts;
using BankDemo.Infrastructure.Config;
using BankDemo.Infrastructure.ExtensionMethods;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddSwaggerDoc();
builder.Services.AddDbContext<BankOneContext>(ctx =>
{
    var connectionString = builder.Configuration["BankOneConnectionString"];
    ctx.UseSqlServer(connectionString);
});
builder.Services.AddScoped<ResponseTimeMiddleware>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithVersioning();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCustomMiddleWare();
app.MapControllers();

app.Run();
