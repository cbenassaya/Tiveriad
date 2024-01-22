#region

using DataReference.Integration;
using DataReference.Integration.Filters;
using DataReference.Integration.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.DataReferences.Apis.Microsoft.DependencyInjection;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.Microsoft.DependencyInjection;

#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<DbContext, DefaultContext>(options =>
{
    var logger = builder.Services.BuildServiceProvider().GetService<ILogger<DefaultContext>>();
    if (logger != null)
        options.LogTo(message => { logger.LogInformation(message); }).EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    options.UseSqlite("Data Source=datareference.db");
});
builder.Services.AddRepositories(typeof(EFRepository<,>), typeof(Civility));

var serviceProvider = builder.Services.BuildServiceProvider();
var defaultContext = serviceProvider.GetRequiredService<DbContext>();
defaultContext.Database.EnsureCreated();

builder.Services.AddSingleton<ITenantService<string>, TenantService>();
builder.Services.AddSingleton<IKeyParser<string>, KeyParser>();
builder.Services.AddDataReferences(typeof(Civility).Assembly);
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(Civility).Assembly); });
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});
builder.Services.AddMvc(opt => { opt.Filters.Add<TransactionActionFilter>(); });
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
app.Run();