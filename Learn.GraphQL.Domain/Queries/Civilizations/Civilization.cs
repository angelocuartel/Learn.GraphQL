using Learn.GraphQL.Domain.Queries.Leaders;

namespace Learn.GraphQL.Domain.Queries.Civilizations;

public abstract class Civilization
{
    public long CivilizationId { get; private set; }
    public Leader Leader { get; private set; }
    public string Capital { get; private set; }

    public DateTime DateEstablished { get; private set; }

    public Civilization(Leader leader, string capital)
    {
        Leader = leader;
        Capital = capital;
        DateEstablished = DateTime.Now;
    }

    public abstract List<string> GetGovernors();

    public abstract string GetName();


}
