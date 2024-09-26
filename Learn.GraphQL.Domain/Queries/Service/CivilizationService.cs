using Learn.GraphQL.Domain.Queries.Civilizations;
using Learn.GraphQL.Domain.Queries.Leaders;
using Learn.GraphQL.Domain.Queries.Traits;


namespace Learn.GraphQL.Domain.Queries.Service;
public sealed class CivilizationService
{

    public List<Civilization> GetCivilizations() =>
        new List<Civilization>()
        {
            new Japan(new NobuNaga(new List<Trait>
            {
                new Expansionist(),
                new Militaristic()
            }), "Kyoto"),


        };
}
