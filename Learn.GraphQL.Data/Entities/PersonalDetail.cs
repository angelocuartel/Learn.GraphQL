namespace Learn.GraphQL.Data.Entities;

public class PersonalDetail
{
    public long PersonalDetailId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }
    public virtual User? User { get; set; }
}
