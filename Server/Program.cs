global using Microsoft.EntityFrameworkCore;
global using EmailPlanner_Alpha.Server.Data;
global using EmailPlanner_Alpha.Server.Services.EmailService;
global using EmailPlanner_Alpha.Server.Services.TicketService;

using Microsoft.AspNetCore.ResponseCompression;
using EmailPlanner_Alpha.Server.Background_Services;
using EmailPlanner_Alpha.Server.Services.UserService;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkVFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSn9Qd0FiXHpeeXFUQw==;Mgo+DSMBPh8sVXJ0S0J+XE9AflRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdURgWHtfdXFVT2ZUVA==;ORg4AjUWIQA/Gnt2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkZiWn5acXFQRmlUVkE=;MTMxNDU3M0AzMjMwMmUzNDJlMzBHMStoT1ZYWWRIVWJWRlRHbkxJRUVkVTROVEJ1Y2p6K1o5V2lCYUhMU1BvPQ==;MTMxNDU3NEAzMjMwMmUzNDJlMzBDU0ZpS1VFc2V5aXVvRjJLTXN2VkY4c1dzZjg5MnErcGFiSzloMktCWlpZPQ==;NRAiBiAaIQQuGjN/V0Z+WE9EaFtKVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUVgWHxfdHVQQ2FcWERz;MTMxNDU3NkAzMjMwMmUzNDJlMzBHdDRjbDRMR0ZSU2pDcGlvTnRKMXEzSWk2NGhLVFdwUFFIRVo4aWJvUUZzPQ==;MTMxNDU3N0AzMjMwMmUzNDJlMzBJaGlVSDVwOXpHZTVnRUl2MERqUENRbnBKQVVIdldLdGZCMXc2dVErTDJ3PQ==;Mgo+DSMBMAY9C3t2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkZiWn5acXFQR2JYUEE=;MTMxNDU3OUAzMjMwMmUzNDJlMzBtNnNrK3hYcWZ1ODl0NmxIQThZMHBDdDBOeStQc2FvZXhHTk9QOWM3alc0PQ==;MTMxNDU4MEAzMjMwMmUzNDJlMzBtNXNuZ1pQbzBjYmxmOEEyNUV2NkR6Q1pmSTZvR1QxNTBlaDRqTUx3WHJFPQ==;MTMxNDU4MUAzMjMwMmUzNDJlMzBHdDRjbDRMR0ZSU2pDcGlvTnRKMXEzSWk2NGhLVFdwUFFIRVo4aWJvUUZzPQ==");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IUserService, UserService>();

//Add background services
builder.Services.AddHostedService<EmailRetrievalService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//HttpContextAccessor!
builder.Services.AddHttpContextAccessor();

//Swagger! (with added authorization)
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
//Authentication!
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

//Authorization!
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
