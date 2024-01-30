using Tiveriad.Integration.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.local.json");


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configurePolicy =>
    {
        configurePolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddInfrastrureService();
builder.Services.AddIdentities();
builder.Services.AddDatabase();
builder.Services.AddPublisher();
builder.Services.AddDocumentProvider();
builder.Services.AddRabbitMq();
builder.Services.AddKeycloak();

builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseRouting(); // This adds EndpointRoutingMiddleware
app.UseCors();
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapControllers();
app.UseLoggerFile();
app.Run();

namespace Tiveriad.Integration
{
    public partial class Program
    {
    
    }
}
