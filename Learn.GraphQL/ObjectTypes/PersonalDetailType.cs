using Learn.GraphQL.Domain;

namespace Learn.GraphQL.ObjectTypes;

public class PersonalDetailType : ObjectType<PersonalDetail> 
{
    protected override void Configure(IObjectTypeDescriptor<PersonalDetail> descriptor)
    {
        Name = "PersonalDetail";
        Description = "Contains additional personal information of user.";

        descriptor.Field(i => i.PersonalDetailId).Ignore();
        descriptor.Field(i => i.FirstName).Type<StringType>().Description("First name of the user.");
        descriptor.Field(i => i.LastName).Type<StringType>().Description("Last name of the user.");
        descriptor.Field(i => i.BirthDate).Type<DateType>().Description("Date of birth of the user.");

        base.Configure(descriptor);
    }
}
