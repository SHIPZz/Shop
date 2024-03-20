using DAL.Shop;
using Microsoft.EntityFrameworkCore;
using Shop.Profiles;
using Shop.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DeviceService>();
builder.Services.AddScoped<OrderedDeviceService>();
builder.Services.AddScoped<ShoppingCartService>();
builder.Services.AddScoped<UnitOfWork>();

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
    pattern: "{controller=Device}/{action=GetById}/{id?}");

app.Run();

app.UseEndpoints(endpoints => endpoints.MapControllers());