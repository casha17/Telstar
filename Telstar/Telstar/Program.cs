using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Telstar.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
/*var connectionString = builder.Configuration.GetConnectionString("Server=localhost;Database=SalesDb;User Id=SA;Password=A!VeryComplex123Password;MultipleActiveResultSets=true") ?? throw new InvalidOperationException("Connection string 'TelstarIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<TelstarIdentityDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TelstarIdentityDbContext>();
*/

builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
