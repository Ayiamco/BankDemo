using BankDemo.Infrastructure.Config;
using BankDemo.Infrastructure.ExtensionMethods;
using Dapper.BaseRepository.Config;
using Dapper.Repository.interfaces;
using InterBankSettlement.Api.Data.Repositories.Implementations;
using InterBankSettlement.Api.Data.Repositories.Interfaces;
using MediatR;

var builder = WebApplication.CreateBuilder(args);


AppConfig.ConnectionString = builder.Configuration["ConnectionString"];
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBaseRepostiorySetup(options =>
{
    options.DefaultSqlServerConnectionString = AppConfig.ConnectionString;
});
builder.Services.AddScoped(typeof(IRepositoryLogger<>), typeof(RepoLogger<>));
builder.Services.AddScoped<IMerchantRepo, MerchantRepo>();
builder.Services.AddControllers();
builder.Services.AddSwaggerDoc();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithVersioning();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
