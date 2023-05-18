using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;
using SWH.Controllers;
using SWH.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddElectron();
builder.WebHost.UseElectron(args);
builder.Services.AddMudServices();

//FOR CONTROLLERS
builder.Services.AddScoped<IUser, UserController>();
builder.Services.AddScoped<ICompartment, CompartmentController>();
builder.Services.AddScoped<IProduct, ProductController>();
builder.Services.AddScoped<IProductType, ProductTypeController>();
builder.Services.AddScoped<IProject, ProjectController>();

//FOR AUT/AUTH
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();

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
        }
    );
    await window.WebContents.Session.ClearCacheAsync();
    
    window.OnMaximize += Window_OnMaximize; 
    
    window.RemoveMenu();
    
}

void Window_OnMaximize()
{
    
}
