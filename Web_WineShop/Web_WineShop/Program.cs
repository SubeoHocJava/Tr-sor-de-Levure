﻿using Microsoft.EntityFrameworkCore;
using Web_WineShop.Dao;
using Web_WineShop.Services; // Assuming EmailService is in this namespace

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
// Cấu hình DbContext cho SQL Server
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

// Cấu hình route cho Login và Register controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ShoppingCart}/{action=ShoppingCart}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Product}/{action=ProductList}/{id?}"
//);

app.Run();
