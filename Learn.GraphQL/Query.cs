using Learn.GraphQL.ApplicationService.Interface;
using Learn.GraphQL.Domain;

namespace Learn.GraphQL;
public class Query
{
    private readonly IUserRepository<User> _userRepository;

    public Query(IUserRepository<User> userRepository) => _userRepository = userRepository;
    

    public async Task<List<User>> GetUsersAsync() => await _userRepository.GetAllAsync();
}
