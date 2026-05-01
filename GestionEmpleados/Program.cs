using System.IO;
using GestionEmpleados.DA;
using GestionEmpleados.BL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Data and repository
var connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=empleados.db";
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connection));
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

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

app.MapStaticAssets();

// Seed database using script if empty
using (var scope = app.Services.CreateScope())
{
    var env = app.Environment;
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Ensure database and tables exist
    ctx.Database.EnsureCreated();

    if (!ctx.Empleados.Any())
    {
        var scriptPath = Path.Combine(env.ContentRootPath, "script", "init.sql");
        if (File.Exists(scriptPath))
        {
            var sql = File.ReadAllText(scriptPath);
            if (!string.IsNullOrWhiteSpace(sql))
            {
                ctx.Database.ExecuteSqlRaw(sql);
            }
        }
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
