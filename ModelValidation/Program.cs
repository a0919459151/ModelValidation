using Microsoft.AspNetCore.Mvc.Infrastructure;
using ModelValidation.ModelValidators;
using ModelValidation.ModelValidators.Common;
using ModelValidation.Providers;
using ModelValidation.Serivces;

var builder = WebApplication.CreateBuilder(args);

// General
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

// Controller
builder.Services.AddControllersWithViews();

// Provider
builder.Services.AddScoped<PagerProvider>();
builder.Services.AddScoped<ToastrProvider>();

// ModelValidator
builder.Services.AddScoped<CommonModelValidator>();
builder.Services.AddScoped<DropdownModelValidator>();
builder.Services.AddScoped<CheckboxModelValidator>();

// Service
builder.Services.AddScoped<ActivityService>();
builder.Services.AddScoped<DropdownService>();

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
