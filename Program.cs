using System.Net;
using Microsoft.AspNetCore.HttpOverrides;
using MBalbanero_Exam.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC + API
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient<IEthereumService, EtherscanService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Usual middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
    });

    app.UseWhen(ctx => ctx.Request.Path.StartsWithSegments("/api/swagger"), branch =>
    {
        branch.Use(async (context, next) =>
        {
            var ip = context.Connection.RemoteIpAddress;
            if (ip == null || !IPAddress.IsLoopback(ip))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Swagger UI is only available on localhost.");
                return;
            }

            await next();
        });

        branch.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("v1/swagger.json", "My API v1");
            c.RoutePrefix = "api/swagger";
        });
    });
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
