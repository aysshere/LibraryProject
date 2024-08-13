using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.UnitOfWorks;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibraryProjectDb>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddExtensions();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
