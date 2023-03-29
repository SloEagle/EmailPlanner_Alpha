global using EmailPlanner_Alpha.Shared;

using EmailPlanner_Alpha.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.JSInterop;
using EmailPlanner_Alpha.Client.Shared;
using EmailPlanner_Alpha.Client.Services.EmailService;
using EmailPlanner_Alpha.Client.Services.TicketService;
using EmailPlanner_Alpha.Client.Services.UserService;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQl5hQH5WckVjWXlZeHw=;Mgo+DSMBPh8sVXJ1S0d+X1RPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSX1Rf0VmXX9ecHJcRWc=;ORg4AjUWIQA/Gnt2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdExjXHtecHRSRmhb;MTUzMDMwOEAzMjMxMmUzMTJlMzMzNVkzVWV2aEROSmpDcGUvRG1ZU0pFY2UwZU92bXN2VWZIQ0Z5MFp3a3NUeVE9;MTUzMDMwOUAzMjMxMmUzMTJlMzMzNWNMSll4b1JGOW5Wa0Z4S1Z1Q1dZdXpiMXZPMG5YMy80M2diMWdiOHNYdnc9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdUdqWXpacHRVQWhYVg==;MTUzMDMxMUAzMjMxMmUzMTJlMzMzNWd5YUhrZGlsYnNsWHZBdExxcE1haUhNeHRSOFkrbWJtTytSR2lYSmRGR009;MTUzMDMxMkAzMjMxMmUzMTJlMzMzNWFBT3gyZ0RYMjkzL09KNjRpTVVQTEtKRkZVS0p2eCsyY0R0NU1GREZVSFk9;Mgo+DSMBMAY9C3t2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdExjXHtecHRcRWRb;MTUzMDMxNEAzMjMxMmUzMTJlMzMzNWN0eEFDcDhpeEo3NmFsUWFheTgya2Zqc2IrbHUwa0d5VWRIRTc4SEJ0ckU9;MTUzMDMxNUAzMjMxMmUzMTJlMzMzNW93dkk1OXRLdzIxZGkzWDNjc1MzR1NKYmZydG9scGtOMk1wRXN2dlhpVWc9;MTUzMDMxNkAzMjMxMmUzMTJlMzMzNWd5YUhrZGlsYnNsWHZBdExxcE1haUhNeHRSOFkrbWJtTytSR2lYSmRGR009");

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
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();
