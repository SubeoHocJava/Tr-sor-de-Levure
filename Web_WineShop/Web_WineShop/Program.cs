var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
<<<<<<< HEAD
	pattern: "{controller=Wishlist}/{action=Wishlist" + "}/{id?}");
=======
	pattern: "{controller=Admin}/{action=Admin}/{id?}");
>>>>>>> 3859becac8dfba284bc43d35ead8de910393b74a

app.Run();
