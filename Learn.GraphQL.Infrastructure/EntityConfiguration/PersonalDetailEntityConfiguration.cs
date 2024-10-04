using Learn.GraphQL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Learn.GraphQL.Infrastructure.EntityConfiguration;

public class PersonalDetailEntityConfiguration : IEntityTypeConfiguration<PersonalDetail>
{
    public void Configure(EntityTypeBuilder<PersonalDetail> builder)
    {
        builder.ToTable("PersonalDetail")
               .HasKey(i => i.PersonalDetailId);
    }
}
