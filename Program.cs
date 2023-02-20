using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ElectronNET.API;
using SWH.Data;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddElectron();
builder.WebHost.UseElectron(args);
builder.Services.AddMudServices();
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
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

CreateElectronWindow();

app.Run();


async void CreateElectronWindow()
{
    var window = await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
        {
            Width = 1024,
            Height = 768,
            Frame = false,
            Fullscreen = true,
            Kiosk = true
            
        }
        
        
        );
    await window.WebContents.Session.ClearCacheAsync();
    
    window.OnMaximize += Window_OnMaximize; 
    
    window.RemoveMenu();
    
}

void Window_OnMaximize()
{
    
}