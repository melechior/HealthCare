using HealthCare.Infrastructures.Data.SqlServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<HealthCareDbContext>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("HealthCareDb")));


// builder.Services.AddAuthentication(HealthcareAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie(options =>
//     {
//         options.LogoutPath = "/User/logout";
//         options.LoginPath = "/Home/login";
//         options.AccessDeniedPath = "/Home/AccessDenied";
//         options.SlidingExpiration = true;
//         options.ExpireTimeSpan = TimeSpan.FromMinutes(40);
//     });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");


app.Run();