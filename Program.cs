//#define MSSQL
#define ORACLE
//#define POSTGRESQL

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChatApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

#if (MSSQL)
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ChatAppIdentityMSSQLDbContext>();
builder.Services.AddDbContext<ChatAppIdentityMSSQLDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection")));
#elif (POSTGRESQL)
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ChatAppIdentityPostgreDbContext>();
builder.Services.AddDbContext<ChatAppIdentityPostgreDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));
#elif (ORACLE)
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ChatAppIdentityOracleDbContext>();
builder.Services.AddDbContext<ChatAppIdentityOracleDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
#endif

// Add services to the container.
builder.Services.AddRazorPages();

// Configure the HTTP request pipeline.
builder.Services.AddWebOptimizer(pipeline =>
{
    pipeline.AddCssBundle(
        "/styles/stylebundle.css",
        "node_modules/bootstrap/dist/css/bootstrap.min.css",
        "node_modules/bootstrap-icons/font/bootstrap-icons.css",
        "/wwwroot/css/site.css",
        "/wwwroot/css/messages.css"
    ).UseContentRoot();

    pipeline.AddJavaScriptBundle(
        "/scripts/scriptbundle.js",
        "node_modules/@popperjs/core/dist/umd/popper.min.js",
        "node_modules/jquery/dist/jquery.min.js",
        "node_modules/jquery-validation/dist/jquery.validate.min.js",
        "node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js",
        "/wwwroot/js/site.js"
    ).UseContentRoot();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/GeneralError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseWebOptimizer();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
