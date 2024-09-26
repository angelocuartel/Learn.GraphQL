using Learn.GraphQL;
using Learn.GraphQL.ConfigureExtensions;
using Learn.GraphQL.Data;
using Learn.GraphQL.Data.Entities;
using Learn.GraphQL.Domain.Mutation;
using Learn.GraphQL.Domain.Queries.Service;
using Learn.GraphQL.ObjectTypes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("DbConnectionString");

builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlite(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
                .AddMutationType<Mutation>()
                .AddQueryType<Query>()
                .AddAllObjectTypes();

builder.Services.AddScoped<CivilizationService>();
builder.Services.AddScoped<Mutation>();
builder.Services.AddScoped<Query>();
builder.Services.AddScoped<UserService>();

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
