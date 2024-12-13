using Autofac;
using Autofac.Extensions.DependencyInjection;
using HealthCare.Infrastructures.Data.SqlServer;
using HealthCare.Infrastructures.DI;
using HealthCare.Infrastructures.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(
    containerBuilder =>
        containerBuilder.RegisterModule(new DiHandlerModule())
));
builder.Services.AddDbContextPool<HealthCareDbContext>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("HealthCareDb")));


var settings = new Settings();
new ConfigureFromConfigurationOptions<Settings>(builder.Configuration.GetSection("settings")).Configure(settings);
builder.Services.AddSingleton(settings);

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
