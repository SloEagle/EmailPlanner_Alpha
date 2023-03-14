using EmailPlanner_Alpha.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.JSInterop;
using EmailPlanner_Alpha.Client.Shared;
using EmailPlanner_Alpha.Client.Services.EmailService;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkVFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSn9Qd0FiXHpeeXFUQw==;Mgo+DSMBPh8sVXJ0S0J+XE9AflRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdURgWHtfdXFVT2ZUVA==;ORg4AjUWIQA/Gnt2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkZiWn5acXFQRmlUVkE=;MTMxNDU3M0AzMjMwMmUzNDJlMzBHMStoT1ZYWWRIVWJWRlRHbkxJRUVkVTROVEJ1Y2p6K1o5V2lCYUhMU1BvPQ==;MTMxNDU3NEAzMjMwMmUzNDJlMzBDU0ZpS1VFc2V5aXVvRjJLTXN2VkY4c1dzZjg5MnErcGFiSzloMktCWlpZPQ==;NRAiBiAaIQQuGjN/V0Z+WE9EaFtKVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUVgWHxfdHVQQ2FcWERz;MTMxNDU3NkAzMjMwMmUzNDJlMzBHdDRjbDRMR0ZSU2pDcGlvTnRKMXEzSWk2NGhLVFdwUFFIRVo4aWJvUUZzPQ==;MTMxNDU3N0AzMjMwMmUzNDJlMzBJaGlVSDVwOXpHZTVnRUl2MERqUENRbnBKQVVIdldLdGZCMXc2dVErTDJ3PQ==;Mgo+DSMBMAY9C3t2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkZiWn5acXFQR2JYUEE=;MTMxNDU3OUAzMjMwMmUzNDJlMzBtNnNrK3hYcWZ1ODl0NmxIQThZMHBDdDBOeStQc2FvZXhHTk9QOWM3alc0PQ==;MTMxNDU4MEAzMjMwMmUzNDJlMzBtNXNuZ1pQbzBjYmxmOEEyNUV2NkR6Q1pmSTZvR1QxNTBlaDRqTUx3WHJFPQ==;MTMxNDU4MUAzMjMwMmUzNDJlMzBHdDRjbDRMR0ZSU2pDcGlvTnRKMXEzSWk2NGhLVFdwUFFIRVo4aWJvUUZzPQ==");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSyncfusionBlazor();
            builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

            // Set the default culture of the application
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

                        // Get the modified culture from culture switcher
                        var host = builder.Build();
                        var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
                        var result = await jsInterop.InvokeAsync<string>("cultureInfo.get");
                        if (result != null)
                        {
                            // Set the culture from culture switcher
                            var culture = new CultureInfo(result);
                            CultureInfo.DefaultThreadCurrentCulture = culture;
                            CultureInfo.DefaultThreadCurrentUICulture = culture;
                        }

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IEmailService, EmailService>();

await builder.Build().RunAsync();
