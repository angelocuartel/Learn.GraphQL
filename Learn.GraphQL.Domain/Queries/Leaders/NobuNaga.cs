using Learn.GraphQL.Domain.Queries.Traits;

namespace Learn.GraphQL.Domain.Queries.Leaders
{
    public class NobuNaga : Leader
    {
        public NobuNaga(List<Trait> traits)
        {
            Name = nameof(NobuNaga);
            Traits = traits;
        }

    }
}
