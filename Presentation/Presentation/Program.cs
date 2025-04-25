using Core.Interfaces;
using Services.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// 🧠 Register services like controllers
builder.Services.AddControllersWithViews();

// 🧠 Register migration services
var connectionString = "Data Source=localhost;Initial Catalog=ticket-work-history-db;Integrated Security=true;Persist Security Info=True;Trust Server Certificate=True";

builder.Services.AddSingleton<IMigrationService>(_ =>
    new MigrationService(connectionString));
builder.Services.AddHostedService<MigrationHostedService>();

// 🔨 Build the app
var app = builder.Build();

// 🧪 Configure middleware and endpoints
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

// 🚀 Run the app — this will now also run migrations first
app.Run();