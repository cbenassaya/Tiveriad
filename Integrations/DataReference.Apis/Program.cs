using DataReference.Apis;
using Mongo2Go;
using MongoDB.Bson;
using MongoDB.Driver;
using Tiveriad.DataReferences.Apis.Microsoft.DependencyInjection;
using Tiveriad.DataReferences.Apis.Services;
using Tiveriad.Repositories.Microsoft.DependencyInjection;
using Tiveriad.Repositories.MongoDb;
using Tiveriad.Repositories.MongoDb.Repositories;





var builder = WebApplication.CreateBuilder(args);
MongoDbRunner _runner = MongoDbRunner.Start();

var factory = new MongoConnectionFactoryBuilder();

builder.Services
    .ConfigureConnectionFactory<MongoConnectionFactoryBuilder, IMongoDatabase, MongoConnectionConfigurator,
        IMongoConnectionConfiguration>(
        configurator =>
        {
            configurator.SetConnectionString(_runner.ConnectionString);
            configurator.SetDatabaseName("TEST");
        });

builder.Services.AddRepositories(typeof(MongoRepository<>), typeof(Civility));

builder.Services.AddSingleton<ITenantService<ObjectId>, TenantService>();
builder.Services.AddSingleton<IKeyParser<ObjectId>, KeyParser>();
builder.Services.AddDataReferences(typeof(Civility).Assembly);
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Civility).Assembly);
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
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

