using HealthCare.Infrastructures.Data.SqlServer;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HealthCare.Infrastructures.DI;
using HealthCare.Infrastructures.Shared;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

new ContainerBuilder().RegisterModule(new DiHandlerModule());

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LogoutPath = "/User/logout";
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/Home/AccessDenied";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(40);
    });

builder.Services.AddControllersWithViews();

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
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    //app.Urls.Add("http://0.0.0.0:6186");
}
else
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();