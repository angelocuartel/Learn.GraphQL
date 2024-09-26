namespace Learn.GraphQL.Domain.Inputs;

public record UserDto(string? UserName, string? Password, PersonalDetailDto PersonalDetail)
{
}
