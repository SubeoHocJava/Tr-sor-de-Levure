using Microsoft.EntityFrameworkCore;
using Web_WineShop.Dao;
using Web_WineShop.Services; // Assuming EmailService is in this namespace

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext cho SQL Server
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình Session (và cache phân phối)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Thiết lập thời gian phiên
});

// Đăng ký EmailService và SmtpClient
builder.Services.AddSingleton<EmailService>();

// Thêm Controllers và Views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình HTTP request pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();  // Đảm bảo session được sử dụng

// Cấu hình route cho Login và Register controller
app.MapControllerRoute(
    name: "login",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
