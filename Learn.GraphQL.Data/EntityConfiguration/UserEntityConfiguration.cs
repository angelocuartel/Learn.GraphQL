using Learn.GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Learn.GraphQL.Data.EntityConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User")
               .HasKey(i => i.UserId);

        builder.HasOne(i => i.PersonalDetail)
               .WithOne(i => i.User)
               .HasForeignKey<User>(i => i.PersonalDetailId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
