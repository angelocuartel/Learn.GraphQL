using Learn.GraphQL.Data.Entities;
using Learn.GraphQL.Domain.Mutation;
using Learn.GraphQL.Domain.Queries.Civilizations;
using Learn.GraphQL.Domain.Queries.Service;

namespace Learn.GraphQL
{
    public class Query
    {
        private readonly CivilizationService _civilizationService;
        private readonly UserService _userService;
        public Query(CivilizationService civilizationService, UserService userService)
        {
            _civilizationService = civilizationService;
            _userService = userService;
        }

        public IEnumerable<Civilization> GetCivilizations() => _civilizationService.GetCivilizations();

        public async Task<List<User>> GetUsers() => await _userService.GetAllAsync();
    }
}
