
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Multitenancy.Integration;
using Multitenancy.Integration.Extensions;
using Multitenancy.Integration.Infrastructure;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories.Microsoft.DependencyInjection;
using Tiveriad.Repositories.MongoDb.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.local.json");

builder.Services.AddRepositories(typeof(MongoRepository<>), typeof(Organization));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddMultitenancy();
builder.Services.AddDatabase();
builder.Services.AddPublisher();
builder.Services.AddRabbitMq();
builder.Services.AddKeycloak();

builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { });
var app = builder.Build();
app.UseRouting(); // This adds EndpointRoutingMiddleware
app.UseCors();
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapControllers();
app.Run();
