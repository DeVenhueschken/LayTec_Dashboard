using LayTec_Dashboard.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using LayTec_Dashboard.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IGetCurrentDashBoard, GetCurrentDashBoard>();
builder.Services.AddSingleton<IGetCurrentDateTimeService, GetCurrentDateTimeService>();
builder.Services.AddSingleton<IGetRoomTemperatureService, GetRoomTemperatureService>();
//builder.Services.AddSingleton<GetRoomTemperatureService>();

//builder.Services.AddSingleton<InjectableService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
