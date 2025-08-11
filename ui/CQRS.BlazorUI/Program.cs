using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using CQRS.BlazorUI;
using CQRS.BlazorUI.HttpRepositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

var uri = "http://localhost:5043/api/";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(uri) });

builder.Services.AddScoped<ITodoHttpRepository, TodoHttpRepository>();

await builder.Build().RunAsync();
