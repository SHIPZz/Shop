using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Commands;
using Shop.Data;
using Shop.Profiles;
using Shop.Services;
using Shop.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddScoped<UserDatabaseService>();
builder.Services.AddScoped<DeviceDatabaseService>();
builder.Services.AddScoped<OrderedDeviceDatabaseService>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IValidator<AddOrderedDeviceModelCommand>, AddDeviceModelCommandValidator>();

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
    pattern: "{controller=Device}/{action=Device}/{id?}");

app.Run();