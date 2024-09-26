namespace Learn.GraphQL.Data.Entities;
public class User
{
    public long UserId { get; set; }
    public long PersonalDetailId { get; set; }  
    public string? UserName { get; set; }
    public string? Password { get; set; }

    public virtual PersonalDetail? PersonalDetail { get; set; }
}

