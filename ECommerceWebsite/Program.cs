using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

var settings = MongoClientSettings.FromConnectionString(builder.Configuration.GetConnectionString("DbConnection"));
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
var client = new MongoClient(settings);

builder.Services.AddDbContext<RepositoryDbContext>(options => options.UseMongoDB(client, "ECommerceDatabase"));


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
