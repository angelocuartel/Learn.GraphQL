namespace Learn.GraphQL.Domain.Queries.Traits;

public class Expansionist : Trait
{
    public Expansionist()
    {
        MilitaryPoints = 8;
        SciencePoints = 6;
        CulturalPoints = 3;
        ReligiousPoints = 3;
    }
    public override string GetDescription() => "Likes civilization that expands border, dislikes civilization that does not expand border";
}

