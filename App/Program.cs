using App;
using App.Auth;
using App.Contracts;
using App.Services;
using Blazored.LocalStorage;
using IdeasSharing.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton(new HttpClient
{
	BaseAddress = new Uri("https://localhost:7020")
});

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7020"))
	.AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

//builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
