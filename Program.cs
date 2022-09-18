using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChatApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var usedConnection = builder.Configuration.GetSection("UsedConnection").Value;
var connections = builder.Configuration.GetSection("ConnectionStrings").GetChildren();

foreach (var connection in connections)
{
  var connectionName = connection.Key;
  var connectionString = connection.Value;

  if (connectionName == usedConnection)
  {
    if (usedConnection == "Npgsql")
    {
      builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ChatAppIdentityPostgreDbContext>();
      builder.Services.AddDbContext<ChatAppIdentityPostgreDbContext>(options =>
        options.UseNpgsql(connectionString));
    }
    else if (usedConnection == "Oracle")
    {
      builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ChatAppIdentityOracleDbContext>();
      builder.Services.AddDbContext<ChatAppIdentityOracleDbContext>(options =>
        options.UseOracle(connectionString));
    }
    else
    {
      builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ChatAppIdentityMSSQLDbContext>();
      builder.Services.AddDbContext<ChatAppIdentityMSSQLDbContext>(options =>
        options.UseSqlServer(connectionString));
    }
  }
}

// Add services to the container.
builder.Services.AddRazorPages();

// Configure the HTTP request pipeline.
builder.Services.AddWebOptimizer(pipeline =>
{
  pipeline.AddCssBundle(
      "/css/stylebundle.css",
      "node_modules/bootstrap/dist/css/bootstrap.min.css",
      "node_modules/bootstrap-icons/font/bootstrap-icons.css",
      "wwwroot/css/shared.css"
  ).UseContentRoot();

  pipeline.AddJavaScriptBundle(
      "/js/scriptbundle.js",
      "node_modules/bootstrap/dist/js/bootstrap.bundle.min.js",
      "node_modules/jquery/dist/jquery.min.js",
      "node_modules/jquery-validation/dist/jquery.validate.min.js",
      "node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js",
      "wwwroot/js/shared.js"
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
