using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChatApp.Areas.Identity.Data;
using System.Runtime.InteropServices;


var builder = WebApplication.CreateBuilder(args);

// if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
// {
//     builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//         .AddEntityFrameworkStores<ChatAppIdentityOracleDbContext>();
//     builder.Services.AddDbContext<ChatAppIdentityOracleDbContext>(options =>
//         options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
// }
// else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
// {
//     builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//         .AddEntityFrameworkStores<ChatAppIdentityPostgreDbContext>();
//     builder.Services.AddDbContext<ChatAppIdentityPostgreDbContext>(options =>
//         options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));
// }

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ChatAppIdentityPostgreDbContext>();
builder.Services.AddDbContext<ChatAppIdentityPostgreDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

// Add services to the container.
builder.Services.AddRazorPages();

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
app.UseAuthorization();

app.MapRazorPages();

app.Run();
