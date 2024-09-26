namespace Learn.GraphQL.Domain.Queries.Traits
{
    public abstract class Trait
    {
        public double MilitaryPoints { get; protected set; }
        public double SciencePoints { get; protected set; }
        public double CulturalPoints { get; protected set; }
        public double ReligiousPoints { get; protected set; }

        public abstract string GetDescription();


    }
}
