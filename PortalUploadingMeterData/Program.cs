using Microsoft.EntityFrameworkCore;
using PortalUploadingMeterData.Models;
using MetersCenter.Core_;
using MetersCenter.Data;
using MetersCenter.Core_.Contexts;
using MetersCenter.Core_.Interfaces;
using MetersCenter.Core_.Repos;
using MetersCenter.Business.Interfaces;
using MetersCenter.Business.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using PortalUploadingMeterData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

builder.Services.AddScoped(typeof(IMeterDataRepo), typeof(MeterDataRepo));
builder.Services.AddScoped(typeof(IMeterService), typeof(MeterService));
builder.Services.AddScoped(typeof(ISuppliesRepo), typeof(SuppliesRepo));
builder.Services.AddScoped(typeof(ISuppliesService), typeof(SuppliesService));
builder.Services.AddScoped(typeof(IMeterProviderRepo), typeof(MeterProviderRepo));
builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
builder.Services.AddScoped(typeof(IProtectedData), typeof(ProtectedData));

/*builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))

        };
        //options.Events = new JwtBearerEvents
        //{
        //    OnMessageReceived = context =>
        //    {
        //        var accessToken = context.Request.Cookies["token"];

        //        if (!string.IsNullOrEmpty(accessToken))
        //        {
        //            context.Token = accessToken;
        //        }

        //        return Task.CompletedTask;
        //    }
        //};
    });*/

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Login/AdminLogin";
            //options.AccessDeniedPath = "/Login/AdminLogin";
        });

builder.Services.AddAuthorization();
builder.Services.AddAntiforgery();

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

app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<JWTMiddleware>(); 

//app.UseEndpoints(endpoints =>endpoints.MapControllers());
//app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=AdminLogin}/{id?}");


app.Run();
