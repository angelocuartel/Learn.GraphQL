using Learn.GraphQL.ApplicationService.Interface;
using Learn.GraphQL.Domain;
using Learn.GraphQL.Infrastructure.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Learn.GraphQL.Infrastructure.ConfigureExtensions
{
    public static partial class ConfigureExtensions
    {
        public static void AddService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository<User>, UserRepository>();
        }
    }
}
