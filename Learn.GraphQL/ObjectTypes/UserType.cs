using Learn.GraphQL.Domain;

namespace Learn.GraphQL.ObjectTypes
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            Name = "User";
            Description = "User object used for User operations.";

            descriptor.Field(i => i.UserId).Ignore();
            descriptor.Field(i => i.PersonalDetailId).Ignore();
            descriptor.Field(i => i.UserName).Type<StringType>().Description("set username for the user.");
            descriptor.Field(i => i.Password).Type<StringType>().Description("set password.");

            base.Configure(descriptor);
        }
    }
}
