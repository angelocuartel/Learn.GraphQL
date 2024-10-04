using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Learn.GraphQL.Infrastructure.ConfigureExtensions;
public static partial class ConfigureExtensions
{
    public static void AddDatabaseContext(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<DatabaseContext>(opt => opt.UseSqlite(connectionString));
    }
}
