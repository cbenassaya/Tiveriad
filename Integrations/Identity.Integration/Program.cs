#region

using Identity.Integration.Extensions;

#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPersistence()
    .AddServices()
    .AddCqrs()
    .AddValidators()
    .AddMappers()
    .AddPipelines()
    .AddEndPointServices();

var app = builder.Build();
app
    .UseLoggerFile()
    .UseMiddlewareParseToken()
    .UseEndpointRoutingMiddleware();
app.MapControllers();
app.Run();