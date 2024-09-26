using Learn.GraphQL.Domain.Queries.Traits;

namespace Learn.GraphQL.Domain.Queries.Leaders
{
    public class Leader
    {

        public string? Name { get; set; }

        public List<Trait>? Traits { get; set; }
    }
}
