namespace Learn.GraphQL.Domain.Queries.Traits
{
    public class Militaristic : Trait
    {
        public Militaristic()
        {
            MilitaryPoints = 10;
            SciencePoints = 5;
            CulturalPoints = 0;
            ReligiousPoints = 0;
        }
        public override string GetDescription() => "Likes civilization that construct military buildings and build military army, dislikes civilization that does not construct military buildings and does not build military army.";
    }
}
