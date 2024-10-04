using Learn.GraphQL.Domain;

namespace Learn.GraphQL.ApplicationService.Interface;
public interface IUserRepository<T> : IBaseRepository<T> where T : User
{
}
