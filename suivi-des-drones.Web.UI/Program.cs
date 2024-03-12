using suivi_des_drones.Core.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Application.Repositories;
using suivi_des_drones.Core.Infrastructure.Web.Middlewares;
using Microsoft.AspNetCore.Identity;


using suivi_des_drones.Core.Infrastructure;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
            //    .AddRazorPagesOptions(options =>
            //     {
            //         options.Conventions.AddPageRoute("/CreateDrone", "creation-drone");
            //});
        string connectionString = builder.Configuration.GetConnectionString("DroneContext");                                                                                                                                                                                                                                                                                                                                                              

builder.Services.AddDbContext<DronesDbContext>(options =>
    {
        options.UseSqlServer(connectionString);                                                                                                                                                                                                                                                                                                                 
});

builder.Services.AddDefaultIdentity<AuthenticationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AuthenticationContext>();

builder.Services.AddDbContext<AuthenticationContext>(options =>
                options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDroneDataLayer, SqlServerDroneDataLayer>();
builder.Services.AddScoped<IUserDataLayer, SqlServerUserDataLayer>();
builder.Services.AddScoped<IDroneRepository, DroneRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseSession();
app.UseAuthorization();

app.MapRazorPages();

app.Run();


app.UseRedirectIfNotConnected();