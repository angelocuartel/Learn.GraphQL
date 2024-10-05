using Learn.GraphQL;
using Learn.GraphQL.Infrastructure.ConfigureExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("DbConnectionString");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
                .AddMutationType<Mutation>()
                .AddQueryType<Query>()
                .AddGraphQLTypes()
                .UsePersistedQueryPipeline()
                .AddReadOnlyFileSystemQueryStorage("./QueryStore");

builder.Services.AddScoped<Mutation>();
builder.Services.AddScoped<Query>();

builder.Services.AddService();
builder.Services.AddDatabaseContext(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.MapGraphQL();

app.Run();
