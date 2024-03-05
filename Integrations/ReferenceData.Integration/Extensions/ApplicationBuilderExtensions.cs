using ReferenceData.Integration.Apis.Middlewares;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace ReferenceData.Integration.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseLoggerFile(this IApplicationBuilder application)
    {
        var hostingEnvironment = application.ApplicationServices.GetRequiredService<IHostingEnvironment>();

        var loggerFactory = application.ApplicationServices.GetRequiredService<ILoggerFactory>();

        var logsPath = Path.Combine(hostingEnvironment.ContentRootPath, "Logs", "Log-{Date}.txt");
        loggerFactory.AddFile(logsPath);
        return application;
    }
    
    public static IApplicationBuilder UseMiddlewareParseToken(this IApplicationBuilder app)
    {
        
        var environment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
        if (environment.IsDevelopment())
        {
            app.UseMiddleware<MokTokenMiddleware>();
        }
        
        app.UseMiddleware<ParseTokenMiddleware>();
        
        return app;
    }

    public static IApplicationBuilder UseEndpointRoutingMiddleware(this IApplicationBuilder app)
    {
        app.UseRouting(); // This adds EndpointRoutingMiddleware
        app.UseCors();
        var environment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        };
        app.UseHttpsRedirection();
        return app;
    }
}