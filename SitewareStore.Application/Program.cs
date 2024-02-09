using SitewareStore.Infra.Data.Extensions;
using SitewareStore.Domain.Extensions;
using SitewareStore.Service.Extensions;
using SitewareStore.Infra.CrossCutting.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureStoreAutoMapper();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureDbConnectionString();

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
