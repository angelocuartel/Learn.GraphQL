using Learn.GraphQL.Domain.Queries.Leaders;

namespace Learn.GraphQL.Domain.Queries.Civilizations
{
    public class Japan : Civilization
    {
        public Japan(Leader leader, string capital) : base(leader, capital)
        {

        }

        public override List<string> GetGovernors()
        =>
            new List<string>()
            {
                "Hakuro",
                "Nansuka",
                "Igo",
                "haksu",
                "Ida"
            };


        public override string GetName() => nameof(Japan);
    }
}
