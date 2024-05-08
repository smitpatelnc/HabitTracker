using HabitTracker.Data;
using HabitTracker.Models;
using HabitTracker.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IHabitService, HabitService>();
builder.Services.AddScoped<FoodService>();
builder.Services.AddScoped<ArticleService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


// DbContext with SQLite 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Add Authentication
app.UseAuthentication();

// Add Authorization
app.UseAuthorization();

app.MapBlazorHub(); 
app.MapFallbackToPage("/_Host");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    DBInitializer.Initialize(context);
}
app.Run();
