using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using S00254903_WebApp.Data;
using S00254903_ConsoleApp;

var builder = WebApplication.CreateBuilder(args);

#region Q3 (a) In the MVC project create a CRUD scaffold for students.
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();  // ← ADD THIS LINE TO AVOID ERRORS WITH RAZOR PAGES, IDK

// Configure your DbContext
builder.Services.AddDbContext<ConsoleStudentContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

// Configure Identity DbContext (SEPARATE DATABASE!)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("IdentityConnection")));

// Add Identity services
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
