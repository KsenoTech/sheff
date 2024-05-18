using Microsoft.EntityFrameworkCore;
using WebSheff.Data;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using WebSheff.ApplicationCore.DomModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.Infrastructure.BLL.Services;
using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.Infrastructure.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
       .AllowAnyHeader()
       .AllowAnyMethod();
    });
});


// Add services to the container
builder.Services.AddIdentity<User, IdentityRole>( options => {
        options.User.RequireUniqueEmail = true;
    }).AddEntityFrameworkStores<SheffContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<SheffContext>();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler
                                                                        = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IDbRepository, DbRepository>();
builder.Services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
builder.Services.AddScoped<ISmetaService, SmetaService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddLogging();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "SheffApp";
    options.LoginPath = "/";
    options.AccessDeniedPath = "/";
    options.LogoutPath = "/";
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    // Возвращать 401 при вызове недоступных методов для роли
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});


//параметры неудачных входов
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;
});



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var sheffContext = scope.ServiceProvider.GetRequiredService<SheffContext>();
    await SheffContextSeed.SeedAsync(sheffContext);
    await IdentitySeed.CreateUserRoles(scope.ServiceProvider);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Logger.LogInformation("Starting the app");

app.Run();
