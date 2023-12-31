var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(3600);
});

builder.Services.AddScoped(sp => new HttpClient()
{
	BaseAddress = new Uri("https://localhost:7055/")
});
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
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		"Admin",
		"{area:exists}/{controller=Home}/{action=Index}/{id?}");
	endpoints.MapControllerRoute(
		"default",
		"{controller=Home}/{action=Index}/{id?}");
});

app.Run();