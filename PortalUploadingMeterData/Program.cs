using Microsoft.EntityFrameworkCore;
using PortalUploadingMeterData.Models;
using MetersCenter.Core_;
using MetersCenter.Data;
using MetersCenter.Core_.Contexts;
using MetersCenter.Core_.Interfaces;
using MetersCenter.Core_.Repos;
using MetersCenter.Business.Interfaces;
using MetersCenter.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

builder.Services.AddScoped(typeof(IMeterDataRepo), typeof(MeterDataRepo));
builder.Services.AddScoped(typeof(IMeterService), typeof(MeterService));
builder.Services.AddScoped(typeof(ISuppliesRepo), typeof(SuppliesRepo));
builder.Services.AddScoped(typeof(ISuppliesService), typeof(SuppliesService));
builder.Services.AddScoped(typeof(IMeterProviderRepo), typeof(MeterProviderRepo));

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
    pattern: "{controller=Supplies}/{action=UploadExcel}/{id?}");

app.Run();
