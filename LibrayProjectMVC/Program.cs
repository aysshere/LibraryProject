using Bussiness.Abstract;
using Bussiness.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<IBooksStocksService, BookStocksManager>();
builder.Services.AddScoped<IAccountService, AccountManager>();
builder.Services.AddScoped<IBookCategoriesService, BookCategoriesManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<IUsersBooksService, UsersBooksManager>();
builder.Services.AddScoped<IUsersService, UsersManager>();




builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
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
