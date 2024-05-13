using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZenPharm.BL.Implementations;
using ZenPharm.BL.Implementations.Configs;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL;
using ZenPharm.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(_ => new ApplicationDbContext(builder.Configuration.GetConnectionString("SqliteDbName")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection(CloudinarySettings.OptionKey));
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection(SendGridSettings.OptionKey));
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IFeedbackService, FeedbackService>();

builder.Services.AddScoped<IProdTypeService, ProdTypeService>();

builder.Services.AddScoped<MockupEmail>();

builder.Services.AddDefaultIdentity<ZenPharmUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
