using Blazored.LocalStorage;
using BlazorWASMProgressive;
using BlazorWASMProgressive.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IndexedDbService>();
builder.Services.AddScoped<DatabaseSyncService>();
//builder.Services.AddHostedService<DatabaseSyncService>();

await builder.Build().RunAsync();
